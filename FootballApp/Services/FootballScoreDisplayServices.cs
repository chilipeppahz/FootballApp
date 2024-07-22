using FootballApp.Services;
using FootballChallenge.Models;
using Microsoft.Extensions.Logging;

namespace FootballApp.Services
{
    public class FootballScoreDisplay
    {
        private readonly ILogger<FootballScoreDisplay> _logger;

        public FootballScoreDisplay(ILogger<FootballScoreDisplay> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void DisplayScores(List<TeamStatistics> stats)
        {
            var sortedStats = stats.OrderByDescending(x => x.Points)
                                   .ThenBy(y => y.TeamName);

            foreach (var team in sortedStats)
            {
                _logger.LogInformation($"Team: {team.TeamName}, Points: {team.Points}, Wins: {team.Win}, Losses: {team.Lose}, Draws: {team.Draw}, Win Percentage: {(team.MatchNumber == 0 ? 0 : (double)team.Win / team.MatchNumber * 100):0.00}%");
            }
        }
    }
}
