namespace c5m._2d6Dungeon;

public class DoorSelections
{
    public Dictionary<Direction, Exit> Exits { get; set; }

    public Exit? SelectedExit { get; set; } = null;

    public DoorSelections(Dictionary<Direction, Exit> exits){
        Exits = exits;
    }

}
