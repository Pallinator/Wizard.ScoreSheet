using Microsoft.AspNetCore.Mvc;

namespace Wizard.ScoreSheet.Models
{
    public class ActiveScoreSheet : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
