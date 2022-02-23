using Microsoft.AspNetCore.Mvc;

namespace Wizard.ScoreSheet.Models
{
    public class ActiveScoreSheet
    {
           public List<PlayerModel> Players { get; set; }
            public int Bid { get; set; }
            public int Round { get; set; }
            public int Score { get; set; }
    }
}
