namespace TavernQuest.Services;

public interface IVisitService
{
    string VisitId { get; }
    List<string> Orders { get; }
    decimal TotalBill { get; }
    void AddOrder(string item, decimal price);
}

public class VisitService : IVisitService
{
    public string VisitId { get; } = "VIS-" + Guid.NewGuid().ToString()[..8];

    public List<string> Orders { get; } = new();

    public decimal TotalBill { get; private set; }

    public VisitService()
    {
        Console.WriteLine($"[VisitService] New visit started: {VisitId}");
    }

    public void AddOrder(string item, decimal price)
    {
        Orders.Add(item);
        TotalBill += price;
        Console.WriteLine($"[VisitService] ({VisitId}) Ordered \"{item}\" for {price:C}. Total: {TotalBill:C}");
    }
}
