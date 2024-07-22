namespace FootballChallenge.Models

{
    public class TeamStatistics
    {
        public string TeamName { get; set; }
        public int MatchNumber { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public int Points { get; set; }
        public double SuccessRate { get; set; }
    }
}
