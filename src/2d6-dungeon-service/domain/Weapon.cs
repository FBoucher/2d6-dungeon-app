namespace c5m._2d6Dungeon;

public class Weapon
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public class WeaponList
{
#pragma warning disable IDE1006 // Naming Styles
    public List<Weapon>? value { get; set; }
#pragma warning restore IDE1006 // Naming Styles
}

