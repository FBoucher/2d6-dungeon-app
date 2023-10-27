namespace c5m._2d6Dungeon;

public interface ID6Service
{
    // Adventure
    Task<int> GetSaveGameCount();
    Task<AdventurePreviewList?> GetAdventurePreviews();
    Task<Adventure> GetAdventure(int id);

    // Adventurer
    Task<AdventurerPreviewList?> GetAdventurerPreviews();
    Task<Adventurer> GetAdventurer(int id);
    Task<bool> SaveAdventurer(Adventurer player);

    // Room
    Task<Room> RollRoom(int roll, string size);
}
