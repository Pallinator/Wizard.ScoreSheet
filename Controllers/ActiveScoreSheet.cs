using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wizard.ScoreSheet.Models;

namespace Wizard.ScoreSheet.Controllers
{
    public class ActiveScoreSheet : Controller
    {
        public List<PlayerModel> globalPlayers = new List<PlayerModel>();
        private int v;

        public int Bid { get; private set; }
        public int Score { get; private set; } = 0;
        public int Score2 { get; private set; }
        public int trick { get; private set; }
        [HttpGet] 

        public IActionResult Index()
        {
            return View();
        }

        public void AddPlayer(string name)
        {
            // Scope
            // outer variable
            PlayerModel insideFunction = new PlayerModel();

            if (globalPlayers.Count() == 0)
            {
                insideFunction.PlayerName = name; // playerName.Value(); -- Dynamic variable, a variable that can changed based on user input or function logic
                insideFunction.PlayerTurn = false;
                insideFunction.Dealer = false;
                insideFunction.CurrentScore = 0;
                insideFunction.CurrentBid = 0;

                globalPlayers.Add(insideFunction);
                string innerScope = "this can't be accessed outside of this if statement";
            }
            else
            {
                string elseScope = "this can only be seen inside the else statement";
            }


        }

        // this method takes in an argument
        public PlayerModel UpdatePlayerScore(PlayerModel player, int tricks) // <--- this is called an argument 
        {
            // this method will update an individual players score, we will probably want another method that updates all players scores as well
            // calculate the difference between trick and bids
            int guessDifference = player.CurrentBid - tricks;
            // if the diffference is 0 then the player won the bids they guessed this round -- so their score increases
            if (guessDifference == 0)
            {
                // to add onto the player's score, you can call the current player's score in the equation and then add the points
                player.CurrentScore = player.CurrentScore + (player.CurrentBid * 20);
            }
            else
            {
                // if the player didn't guess the right amount of bids their score gets negatively impacted; Math has a lot of built in functions to simplify coding, like below Math.Abs gets the absolute value
                player.CurrentScore = player.CurrentScore - (Math.Abs(guessDifference) * 10);
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

        // end of round Http POST
        public IActionResult UpdateEndOfRound(int tricks)
        {
            int currentDealerId = 0;
            int currentPlayer = 0;
            // update dealer
            foreach (PlayerModel player in globalPlayers)
            {
                if (player.Dealer == true)
                {
                    currentDealerId = (globalPlayers.Count() - 1) == currentPlayer ? 0 : currentPlayer++;

                    player.Dealer = false;
                }

                UpdatePlayerScore(player, tricks);

                player.CurrentBid = 0;

                currentPlayer = currentPlayer++;
            }

            globalPlayers[currentDealerId].Dealer = true;

            // clear global tricks variable

            return View();

        }

        // update dealer

    }
}
