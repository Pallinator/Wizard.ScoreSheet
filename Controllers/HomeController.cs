using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wizard.ScoreSheet.Models;

namespace Wizard.ScoreSheet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public List<PlayerModel> globalPlayers = new List<PlayerModel>();

        public void AddPlayer()
        {
            // Scope
            // outer variable
            PlayerModel insideFunction = new PlayerModel();

            if (globalPlayers.Count() = 0)
	        {
                insideFunction.PlayerName = "Paul"; // playerName.Value(); -- Dynamic variable, a variable that can changed based on user input or function logic
                insideFunction.PlayerTurn = false;
                insideFunction.Dealer = false;
                insideFunction.CurrentScore = 0;
                insideFunction.CurrentBid = 0;

                globalPlayers.Add(insideFunction);
                string innerScope = "this can't be accessed outside of this if statement";
	        } else
            {
                string elseScope = "this can only be seen inside the else statement"
            }

            
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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