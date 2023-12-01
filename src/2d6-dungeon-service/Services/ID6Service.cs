namespace c5m._2d6Dungeon;
using c5m._2d6Dungeon.Game;

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
    Task<bool> AdventurerCreate(Adventurer player);
    

    // Room
    Task<Room> RollRoom(int roll, string size);

    // WeaponManoeuvre
    Task<WeaponList> GetWeapons();
    Task<WeaponManoeuvreList?> GetWeaponManoeuvreList(int weaponId, int level);

     // ArmourPieces
    Task<ArmourPieceList> GetArmourPieces();


    // MagicScroll
    Task<MagicScrollList> GetMagicScrolls();

    // MagicPotion
    Task<MagicPotion> GetInitialMagicPotion();
}
