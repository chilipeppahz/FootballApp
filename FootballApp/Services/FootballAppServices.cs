using FootballApp.Lib;
using FootballChallenge.Models;
using Microsoft.Extensions.Logging;

namespace FootballApp.Services
{
    public class FootballAppServices
    {
        private readonly FileServices _fileCheckerService;
        private readonly ILogger<FootballAppServices> _logger;
        private List<TeamStatistics> _teamStatistics;

        public FootballAppServices(FileServices fileCheckerService, ILogger<FootballAppServices> logger)
        {
            _fileCheckerService = fileCheckerService ?? throw new ArgumentNullException(nameof(fileCheckerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _teamStatistics = new List<TeamStatistics>();
        }

        public void FootballAppService()
        {
            string fileLocation = @"../ResultsData.txt";

            if (_fileCheckerService.FileExists(fileLocation) && !_fileCheckerService.IsFileEmpty(fileLocation))
            {
                var file = File.ReadAllLines(fileLocation);
                List<TeamStatistics> stats = new List<TeamStatistics>();

                foreach (var line in file)
                {
                    var data = line.Split(';');
                    if (data.Length == 3)
                    {

                        if (data[0] != data[1] &&
                            (data[2].Equals(MatchStatus.Win.GetDisplayName()) ||
                            data[2].Equals(MatchStatus.Lose.GetDisplayName()) ||
                            data[2].Equals(MatchStatus.Draw.GetDisplayName())))
                        {

                            var teamA = stats.FirstOrDefault(x => x.TeamName == data[0]) ?? new TeamStatistics { TeamName = data[0] };
                            var teamB = stats.FirstOrDefault(y => y.TeamName == data[1]) ?? new TeamStatistics { TeamName = data[1] };

                            teamA.MatchNumber++;
                            teamB.MatchNumber++;

                            switch (data[2])
                            {
                                case "win":
                                    teamA.Win++;
                                    teamA.Points += (int)MatchStatus.Win;
                                    teamB.Lose++;
                                    break;
                                case "loss":
                                    teamA.Lose++;
                                    teamB.Win++;
                                    teamB.Points += (int)MatchStatus.Win;
                                    break;
                                case "draw":
                                    teamA.Draw++;
                                    teamA.Points++;
                                    teamB.Draw++;
                                    teamB.Points++;
                                    break;
                            }

                            if (!stats.Contains(teamA)) stats.Add(teamA);
                            if (!stats.Contains(teamB)) stats.Add(teamB);


                        }

                    }
                }

                var sortTable = stats
                .OrderByDescending(x => x.Points)
                .ThenBy(y => y.TeamName);

                foreach (var team in sortTable)
                {
                    var winPercentage = team.MatchNumber == 0 ? 0 : (double)team.Win / team.MatchNumber * 100;               
                }
            }

        }

        public List<TeamStatistics> GetTeamStatistics()
        {
            return _teamStatistics;
        }
    }
}

