using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FootballApp.Services;
using FootballChallenge.Models;

public class App
{
    private readonly FootballAppServices _footballAppService;
    private readonly FootballScoreDisplay _footballScoreDisplay;

    public App(FootballAppServices footballAppService, FootballScoreDisplay footballScoreDisplay)
    {
        _footballAppService = footballAppService;
        _footballScoreDisplay = footballScoreDisplay;
    }

    public void Run()
    {
        _footballAppService.FootballAppService();
        List<TeamStatistics> stats = _footballAppService.GetTeamStatistics();
        _footballScoreDisplay.DisplayScores(stats);
    }
}
