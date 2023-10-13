namespace c5m._2d6Dungeon;

public class Adventurer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int HealthPoints { get; set; }
    public int XP { get; set; }
    public int Shift { get; set; }
    public string Discipline { get; set; }
    public int Precision { get; set; }
    public int Weapon { get; set; }
    public int AppliedRunes { get; set; }
    public List<Manoeuvre> Manoeuvres { get; set; }
    public List<ArmourPiece> ArmourPieces { get; set; }
    public List<MagicScoll> MagicScolls { get; set; }
    public int LegendStatusLevelTracker { get; set; }
    public List<MagicPotion> MagicPotions { get; set; }
    public int Bloodied { get; set; }
    public Boolean Fever { get; set; }
    public int Soaked { get; set; }
    public Boolean Pneumonia { get; set; }
    public Coins Coins { get; set; }
    public List<string> Treasures { get; set; }
    public int LiberatedPrisoners { get; set; }
    public List<string> SideQuests { get; set; }
    public FavorOfTheGods FavorOfTheGods { get; set; }
    
    public Adventurer(string name)
    {
        Name = name;
        Level = 1;
        XP = 0;
        Discipline = string.Empty;
        Manoeuvres = new List<Manoeuvre>();
        ArmourPieces = new List<ArmourPiece>();
        MagicScolls = new List<MagicScoll>();
        MagicPotions = new List<MagicPotion>();
        LegendStatusLevelTracker = 0;
        Fever = false;
        Pneumonia = false;
        Coins = new Coins();
        Treasures = new List<string>();
        SideQuests = new List<string>();
        LiberatedPrisoners = 0;
        FavorOfTheGods = new FavorOfTheGods();
    }
}
