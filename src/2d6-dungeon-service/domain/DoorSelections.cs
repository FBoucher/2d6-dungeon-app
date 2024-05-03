namespace c5m._2d6Dungeon;

public class DoorSelections
{
    public Dictionary<char, Exit> Exits { get; set; }

    public Exit? SelectedExit { get; set; } = null;

    public DoorSelections(Dictionary<char, Exit> exits){
        Exits = exits;
    }

}
