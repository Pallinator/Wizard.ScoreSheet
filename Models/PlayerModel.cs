namespace Wizard.ScoreSheet.Models
{
    public class PlayerModel
    {
        public string PlayerName { get; set; }
        public int CurrentScore { get; set; }
        public bool PlayerTurn { get; set; }
        public int CurrentBid { get; set; }
        public bool Dealer { get; set; }

    }
}
