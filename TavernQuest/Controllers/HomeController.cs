using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TavernQuest.Models;
using TavernQuest.Services;

namespace TavernQuest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITavernKeeperService _tavernKeeper;
        private readonly IVisitService _visit;
        private readonly IDiceService _dice1;
        private readonly IDiceService _dice2;

        private static readonly (string Name, decimal Price)[] Menu =
        [
            ("Bread & Butter",         1.50m),
            ("Bowl of Stew",           3.00m),
            ("Roasted Chicken",        7.00m),
            ("Grilled Venison",        9.50m),
            ("Elven Salad",            4.00m),
            ("Dwarven Meat Pie",       6.50m),
            ("Dragon Pepper Soup",     5.00m),
            ("Honey-Glazed Ham",       8.00m),
            ("Fisherman's Catch",      6.00m),
            ("Mushroom Risotto",       5.50m),
            ("Orc Barbecue Ribs",     10.00m),
            ("Halfling Cheese Plate",  4.50m),
            ("Goblin Hot Wings",       3.50m),
            ("Wizard's Firebread",     2.50m),
            ("Giant's Beef Steak",    12.00m),
            ("Forest Berry Pie",       3.00m),
            ("Spiced Mead Cake",       4.00m),
            ("Troll Leg Roast",       11.00m),
            ("Ranger's Trail Mix",     2.00m),
            ("Royal Feast Platter",   15.00m),
        ];

        public HomeController(
            ILogger<HomeController> logger,
            ITavernKeeperService tavernKeeper,
            IVisitService visit,
            IDiceService dice1,
            IDiceService dice2)
        {
            _logger = logger;
            _tavernKeeper = tavernKeeper;
            _visit = visit;
            _dice1 = dice1;
            _dice2 = dice2;
        }

        public IActionResult Index()
        {
            _tavernKeeper.RegisterVisitor();

            var roll1 = _dice1.Roll();
            var roll2 = _dice2.Roll();

            var dish1 = Menu[roll1 - 1];
            var dish2 = Menu[roll2 - 1];

            _visit.AddOrder(dish1.Name, dish1.Price);

            if (roll1 != roll2)
            {
                _visit.AddOrder(dish2.Name, dish2.Price);
            }

            ViewBag.KeeperName = _tavernKeeper.Name;
            ViewBag.TotalVisitors = _tavernKeeper.TotalVisitors;
            ViewBag.VisitId = _visit.VisitId;
            ViewBag.Orders = _visit.Orders;
            ViewBag.TotalBill = _visit.TotalBill;
            ViewBag.Roll1 = roll1;
            ViewBag.Roll2 = roll2;
            ViewBag.Dish1 = dish1.Name;
            ViewBag.Dish2 = dish2.Name;
            ViewBag.DiceSameInstance = ReferenceEquals(_dice1, _dice2);
            ViewBag.Menu = Menu;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}