namespace c5m._2d6Dungeon;
using c5m._2d6Dungeon.Game;
using System.Text.Json;

public class Adventure
{
    public int Id { get; set; } = 0;
    public Adventurer Adventurer { get; set; }
    public Dungeon Dungeon { get; set; }
    public CombatState? CombatState { get; set; }
    GameTurn? GameTurn { get; set; }


    public Adventure()
    {
        Adventurer = new Adventurer(CreationTools.GetAdventurerName());
        Dungeon = new Dungeon();
    }

    public Adventure(AdventurePreview preview){

        Adventurer = new Adventurer(preview.adventurer_name);
        Dungeon = new Dungeon();

        if(string.IsNullOrEmpty(preview.serialiazedObj)){
            // todo: what should happens
        }
        else{
            Adventure aComplete = DatabaseDecode(preview.serialiazedObj);
            Id = aComplete.Id;
            Adventurer = aComplete.Adventurer;
            Dungeon = aComplete.Dungeon;
            GameTurn = aComplete.GameTurn;
        }
    }

    private static Adventure DatabaseDecode(string base64EncodedData) 
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        var jsonAdventure = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        return JsonSerializer.Deserialize<Adventure>(jsonAdventure)!;
    }
}
