namespace c5m._2d6Dungeon;

public class Dungeon
{
    public List<MappedRoom> MappedRooms { get; set; } = new List<MappedRoom>();

    public static MappedRoom StartDungeonLevel(ref DiceResult dResult)
    {
        int area = dResult.PrimaryDice * dResult.SecondaryDice;
        if(area > 12){
            dResult.PrimaryDice =  (int)Math.Ceiling(((decimal)dResult.PrimaryDice / 2));
            dResult.SecondaryDice = (int)Math.Ceiling(((decimal)dResult.SecondaryDice / 2));
            area = dResult.PrimaryDice * dResult.SecondaryDice;
        }
        if(area < 6){
            dResult.PrimaryDice =  3;
            dResult.SecondaryDice = 2; 
        }
        var entryRoom = MappedRoom.DraftCurrentRoom(dResult);
        entryRoom.ExitsCount = 3;
        return entryRoom;
    }
}
