using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var quotes = new List<HymnQuote>
        {
            new HymnQuote { Text = "I Stand All Amazed at the love Jesus offers me. - Hymn #193" },
            new HymnQuote { Text = "Nearer, My God, to Thee. - Hymn #100" },
            new HymnQuote { Text = "Lead, kindly Light, amid th'encircling gloom. - Hymn #97" },
            new HymnQuote { Text = "Because I have been given much, I too must give. - Hymn #219" },
            new HymnQuote { Text = "There is sunshine in my soul today. - Hymn #227" }
        };

            return View(quotes);
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
