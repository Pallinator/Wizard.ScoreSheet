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
                string elseScope = "this can only be seen inside the else statement";
            }

            
        }

        // this method takes in an argument
        public PlayerModel UpdatePlayerScore(PlayerModel player, int tricks) // <--- this is called an argument 
        {
            // this method will update an individual players score, we will probably want another method that updates all players scores as well
            // calculate the difference between trick and bids
            int guessDifference = player.Bid - tricks;
            // if the diffference is 0 then the player won the bids they guessed this round -- so their score increases
            if (guessDifference == 0)
            {
                // to add onto the player's score, you can call the current player's score in the equation and then add the points
                player.Score = player.Score + (player.Bid * 20);
            }
            else
            {
                // if the player didn't guess the right amount of bids their score gets negatively impacted; Math has a lot of built in functions to simplify coding, like below Math.Abs gets the absolute value
                player.Score = player.Score - (Math.Abs(guessDifference) * 10);
            }

            // here we are returning the player again with the updated score
            return player;
        }

        // Pseudo code the logic you think needs to happen to update a bid
        public void UpdatePlayerBid(PlayerModel player, int bids) // <--- what arguments will you need to take in to update the player's bid
        {
            // this probably won't need a method on it's ow but try to map out the how to update the bid

            player.CurrentBid = bids;

            return;
        }

        // end of round
        public void UpdateEndOfRound(List<PlayerModel> players)
        {
            int currentDealerId = 0;
            int currentPlayer = 0;
            foreach (PlayerModel player in players)
            {
                if (player.Dealer == true)
                {
                    currentDealerId = players.Count()-- = currentPlayer ? 0 : currentPlayer++;

                    


                }
                
            }
            // update dealer
            public bool UpdateDealer(PlayerModel players)
            {
                bool player1 = false;
                bool currentDealerId = true;
                bool player2 = false;
                bool player3 = false;
                bool player4 = false;
                bool player5 = false;
            }
            // update scores
            public int UpdatePlayerScore(PlayerModel players)
            {
                m=> UpdatePlayerScore(players, UpdatePlayerScore=)
                 
            }
                
            // clear bids
            public int ClearPlayersBids(List<PlayerModel> players)
            {
               (ClearPlayersBids == 0)
            }

            // clear tricks
            public int ClearPlayersTricks(List<PlayerModel> players)
            {
               (ClearPlayersTricks == 0)
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