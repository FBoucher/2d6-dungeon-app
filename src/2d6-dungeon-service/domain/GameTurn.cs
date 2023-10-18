namespace c5m._2d6Dungeon;

public class GameTurn
{
    public bool IsFinished { get; set; } = false;
    public MappedRoom? CurrentRoom { get; set; }
    public ActionType NextAction { get; set; } = ActionType.RollForARoom;
    public DiceResult? LastDiceResult { get; set; }
    public string? Message { get; set; }


    public GameTurn ContinueTurn(DiceResult dResult)
    {
        switch(NextAction){
            case(ActionType.RollForARoom): RolledForRoom(dResult);
                break;
            case(ActionType.DoubleSizedRoom): FinishDoubleSizedRoom(dResult);
                break;
            case(ActionType.RollForExits): RollForExits(dResult);
                break;
        };
        return this;
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
            case(1): CurrentRoom.Exits = 0;
                break;
            case >=2 and <=3 : CurrentRoom.Exits = 1;
                break;
            case >=5 and <=6 : CurrentRoom.Exits = 2;
                break;
            default: CurrentRoom.Exits = 3;
                break;
        }


        if(CurrentRoom.IsCorridor)
        {
            NextAction = ActionType.EndOfTurn;
            Message = $"You found a corridor with {CurrentRoom.Exits} exits";
        }
        else
        {
            NextAction = ActionType.RollRoomDescription;
            Message = $"There {CurrentRoom.Exits} exits in this room.";
        }

        
    }

    private MappedRoom DraftCurrentRoom(DiceResult dResult){
        return new MappedRoom{
            Width = dResult.PrimaryDice,
            Height = dResult.SecondaryDice,
            IsCorridor = dResult.IsOneDiceOne
        };
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
    RollRoomDescription
}
