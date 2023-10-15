namespace c5m._2d6Dungeon;

public interface ID6Service
{
    Task<AdventurerPreviewList?> GetAdventurerPreviews();
    Task<Adventurer> GetAdventurer(int id);
    Task<bool> SaveAdventurer(Adventurer player);

    // List<int> Roll2Dices();
    // int Roll1Dice();

    Task StartNextTurn();
}
