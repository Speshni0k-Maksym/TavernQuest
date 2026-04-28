namespace TavernQuest.Services;

public interface IDiceService
{
    int LastRoll { get; }
    int Roll(int sides = 20);
}

public class DiceService : IDiceService
{
    private static readonly Random _random = new();

    public int LastRoll { get; private set; }

    public DiceService()
    {
        LastRoll = _random.Next(1, 21);
        Console.WriteLine($"[DiceService] Created. Initial d20 roll: {LastRoll}");
    }

    public int Roll(int sides = 20)
    {
        LastRoll = _random.Next(1, sides + 1);
        Console.WriteLine($"[DiceService] Rolled d{sides}: {LastRoll}");
        return LastRoll;
    }
}
