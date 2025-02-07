using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace c5m._2d6Dungeon;

public class GameTurn
{
    public bool IsFinished { get; set; } = false;
    public MappedRoom? CurrentRoom { get; set; }
    public ActionType NextAction { get; set; } = ActionType.RollForARoom;
    public DiceResult? LastDiceResult { get; set; }
    public string? Message { get; set; }

    public D6Service? d6Service;

    // public GameTurn(D6Service service){
    //     this.d6Service = service;
    // }

    public GameTurn(){

    }

    public async Task<GameTurn> ContinueTurn(DiceResult dResult)
    {
        switch(NextAction){
            case(ActionType.StartDungeonLevel): StartDungeonLevel(dResult);
                break;
            case(ActionType.RollForARoom): RolledForRoom(dResult);
                break;
            case(ActionType.DoubleSizedRoom): FinishDoubleSizedRoom(dResult);
                break;
            case(ActionType.RollForExits): RollForExits(dResult);
                break;
            case(ActionType.RollRoomDefinition): await RollRoomDefinition(dResult);
                break;
        };
        return this;
    }

    private void StartDungeonLevel(DiceResult dResult)
    {
        LastDiceResult = dResult;
        int area = LastDiceResult.PrimaryDice * LastDiceResult.SecondaryDice;
        if(area > 12){
            LastDiceResult.PrimaryDice =  (int)Math.Ceiling(((decimal)LastDiceResult.PrimaryDice / 2));
            LastDiceResult.SecondaryDice = (int)Math.Ceiling(((decimal)LastDiceResult.SecondaryDice / 2));
            area = LastDiceResult.PrimaryDice * LastDiceResult.SecondaryDice;
        }
        if(area < 6){
            LastDiceResult.PrimaryDice =  3;
            LastDiceResult.SecondaryDice = 2; 
        }
        CurrentRoom = DraftCurrentRoom(LastDiceResult);
        CurrentRoom.ExitsCount = 3;
        NextAction = ActionType.DungeonStarted;
        Message = "You are in the dungeon entrance";
    }

    private void RolledForRoom(DiceResult dResult)
    {
        LastDiceResult = dResult;
        if (LastDiceResult.IsDouble)
        {
            if (LastDiceResult.IsDoubleSix)
            {
                CurrentRoom = DraftCurrentRoom(LastDiceResult);
                NextAction = ActionType.DrawRoom;
                Message = $"You found a square room of {LastDiceResult.PrimaryDice} by {LastDiceResult.SecondaryDice}";
            }
            else
            {
                NextAction = ActionType.DoubleSizedRoom;
                Message = "Wow! It's a double size room. Roll 2D6.";
            }
        }
        else
        {
            if (LastDiceResult.IsOneDiceOne)
            {
                CurrentRoom = DraftCurrentRoom(LastDiceResult);
                NextAction = ActionType.RollForExits;
                Message = "You found a corridor. Roll to know how many exists.";
            }
            else
            {
                CurrentRoom = DraftCurrentRoom(LastDiceResult);
                NextAction = ActionType.DrawRoom;
                Message = $"You found a room of {LastDiceResult.PrimaryDice} by {LastDiceResult.SecondaryDice}";
            }
        }
    }

    private void FinishDoubleSizedRoom(DiceResult dResult)
    {
        if(LastDiceResult == null){
            throw new Exception("Lost the first dices result. PLease start the turn again.");
        }
        LastDiceResult.PrimaryDice += dResult.PrimaryDice;
        LastDiceResult.SecondaryDice += dResult.SecondaryDice;
        CurrentRoom = DraftCurrentRoom(LastDiceResult);
        NextAction = ActionType.DrawRoom;
        Message = $"You found this big room of {LastDiceResult.PrimaryDice} by {LastDiceResult.SecondaryDice}";
    }

    private void RollForExits(DiceResult dResult)
    {
        if(CurrentRoom == null){
            throw new Exception("Lost the info about the current room. PLease start the turn again.");
        }

        switch(dResult.PrimaryDice){
            case(1): CurrentRoom.ExitsCount = 0;
                break;
            case >=2 and <=3 : CurrentRoom.ExitsCount = 1;
                break;
            case >=5 and <=6 : CurrentRoom.ExitsCount = 2;
                break;
            default: CurrentRoom.ExitsCount = 3;
                break;
        }


        if(CurrentRoom.IsCorridor)
        {
            NextAction = ActionType.EndOfTurn;
            Message = $"You found a corridor with {CurrentRoom.ExitsCount} other exits";
        }
        else
        {
            NextAction = ActionType.Encounter;
            Message = $"There {CurrentRoom.ExitsCount} other exits in this room.";
        }

        
    }

    private MappedRoom DraftCurrentRoom(DiceResult dResult){
        return new MappedRoom{
            Width = dResult.PrimaryDice,
            Height = dResult.SecondaryDice,
            IsCorridor = dResult.IsOneDiceOne
        };
    }

    private async Task RollRoomDefinition(DiceResult dResult){
        LastDiceResult = dResult;
        int area = LastDiceResult.PrimaryDice * LastDiceResult.SecondaryDice;
        int roll = 0;
        string roomSize;
        Room room;

        //temporary until more data
        Random r = new Random();
        int[]? values;

        switch(area){
            case(<6): 
                //roll = LastDiceResult.PrimaryDice + LastDiceResult.SecondaryDice;
                values = new[] { 2, 3, 4};
                roll = values[r.Next(values.Length)];
                roomSize = "small";
                break;
            case >32 : 
                //roll = LastDiceResult.PrimaryDice + LastDiceResult.SecondaryDice;
                values = new[] { 2, 3, 4};
                roll = values[r.Next(values.Length)];
                roomSize = "large";
                break;
            default: 
                //roll = int.Parse(string.Concat(LastDiceResult.PrimaryDice.ToString(),  LastDiceResult.SecondaryDice.ToString()));
                values = new[] { 11, 12, 13};
                roll = values[r.Next(values.Length)];
                roomSize = "regular";
                break;
        }
        room = await d6Service!.RollRoom(roll, roomSize);
        // //TODO: Is Room Unique?
        CurrentRoom!.Description = room.description;
        //NextAction = ActionType.RollForExits;
        Message = $"Go to the sumary to see all the details of the room.";
    }

}

public enum ActionType
{
    StartDungeonLevel,
    RollForARoom,
    DoubleSizedRoom,
    RollForExits,
    DrawRoom,
    EndOfTurn,
    RollRoomDefinition,
    Encounter,
    DungeonStarted
}
