using FootballClubManagement.Services;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;

namespace FootballClubManagement.Views
{
    public partial class StatisticWindow : MetroWindow
    {
        public StatisticWindow()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            var dataService = new DataService();

            // Get all players and coaches
            var players = dataService.GetAllPlayers();
            var coaches = dataService.GetAllCoaches();

            // LINQ Queries
            var topGoalsPlayer = players.OrderByDescending(p => p.Goals).FirstOrDefault();
            var topAssistsPlayer = players.OrderByDescending(p => p.Assists).FirstOrDefault();
            var youngestPlayer = players.OrderBy(p => p.Age).FirstOrDefault();
            var playerWithHighestGoalRate = players.OrderByDescending(p => (double)p.Goals / p.MatchesPlayed).FirstOrDefault();
            var mostExperiencedCoach = coaches.OrderByDescending(c => c.Experience).FirstOrDefault();
            var oldestCoach = coaches.OrderByDescending(c => c.Age).FirstOrDefault();

            TopGoalsPlayerTextBlock.Text = topGoalsPlayer != null
                ? $"{topGoalsPlayer.Name} ({topGoalsPlayer.Goals} goals)"
                : "No data";

            TopAssistsPlayerTextBlock.Text = topAssistsPlayer != null
                ? $"{topAssistsPlayer.Name} ({topAssistsPlayer.Assists} assists)"
                : "No data";

            YoungestPlayerTextBlock.Text = youngestPlayer != null
                ? $"{youngestPlayer.Name} ({youngestPlayer.Age} years old)"
                : "No data";

            MostExperiencedCoachTextBlock.Text = mostExperiencedCoach != null
                ? $"{mostExperiencedCoach.Name} ({mostExperiencedCoach.Experience} years)"
                : "No data";

            OldestCoachTextBlock.Text = oldestCoach != null
                ? $"{oldestCoach.Name} ({oldestCoach.Age} years old)"
                : "No data";

            PlayerWithHighestGoalRateTextBlock.Text = playerWithHighestGoalRate != null
                ? $"{playerWithHighestGoalRate.Name} ({(double)playerWithHighestGoalRate.Goals / playerWithHighestGoalRate.MatchesPlayed:F2} goals per game)"
                : "No data";
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            Owner?.Show();
            Close();
        }
    }
}
