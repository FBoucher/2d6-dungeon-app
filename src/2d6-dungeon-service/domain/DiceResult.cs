namespace c5m._2d6Dungeon;

public class DiceResult
{
    public DiceRolled DiceRolled { get; set; }
    public int PrimaryDice { get; set; }
    public int SecondaryDice { get; set; }
    public bool IsOneDiceOne { get; set; } = false;
    public bool IsDouble { get; set; } = false;
    public bool IsDoubleSix { get; set; } = false;



    private static List<int> RollDices(int diceCount)
    {
        var die = new List<int> { 1,2,3,4,5,6 };
        var shuffled = die.OrderBy(x => Guid.NewGuid()).Take(diceCount).ToList<int>(); 
        return shuffled;
    }
    public static DiceResult Roll2Dices()
    {
        var result = new DiceResult();
        result.DiceRolled = DiceRolled.TwoD6;
        List<int> dices = RollDices(2);
        result.PrimaryDice = dices.First<int>();
        result.SecondaryDice = dices.Last<int>();
        result.IsOneDiceOne = dices.Contains(1);
        result.IsDoubleSix = (result.PrimaryDice == 6 && result.SecondaryDice == 6) ? true: false;
        return result;
    }

    public static DiceResult Roll1Dice()
    {
        var result = new DiceResult();
        result.DiceRolled = DiceRolled.OneD6;
        result.PrimaryDice = RollDices(1).First();
        result.SecondaryDice = 0;
        return result;
    }


}

public enum DiceRolled
{
    OneD6 = 1,
    TwoD6 = 2
}


