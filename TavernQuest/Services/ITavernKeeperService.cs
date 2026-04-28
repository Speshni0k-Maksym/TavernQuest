namespace TavernQuest.Services;

public interface ITavernKeeperService
{
    string Name { get; }
    int TotalVisitors { get; }
    void RegisterVisitor();
}

public class TavernKeeperService : ITavernKeeperService
{
    public string Name { get; } = "Gormund the Stout";

    public int TotalVisitors { get; private set; }

    public TavernKeeperService()
    {
        Console.WriteLine($"[TavernKeeperService] Tavern keeper \"{Name}\" has opened the tavern!");
    }

    public void RegisterVisitor()
    {
        TotalVisitors++;
        Console.WriteLine($"[TavernKeeperService] Visitor #{TotalVisitors} entered the tavern.");
    }
}
