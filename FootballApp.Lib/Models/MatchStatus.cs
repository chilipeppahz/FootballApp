using System.ComponentModel.DataAnnotations;

namespace FootballChallenge.Models
{
    public enum MatchStatus
    {
        [Display(Name = "loss")]
        Lose,
        [Display(Name = "draw")]
        Draw,
        None,
        [Display(Name = "win")]
        Win      
    }
}
