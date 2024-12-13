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
            var averagePlayerAge = players.Average(p => p.Age);
            var totalGoals = players.Sum(p => p.Goals);
            var totalAssists = players.Sum(p => p.Assists);
            var averagePlayerHeight = players.Average(p => p.Height);
            var playerWithMostMatches = players.OrderByDescending(p => p.MatchesPlayed).FirstOrDefault();
            var totalPlayers = players.Count;
            var totalCoachs = coaches.Count;


            // Display results
            TopGoalsPlayerTextBlock.Text = topGoalsPlayer != null
                ? topGoalsPlayer.DisplayRole() + $" - {topGoalsPlayer.Goals} goals"
                : "No data";

            TopAssistsPlayerTextBlock.Text = topAssistsPlayer != null
                ? topAssistsPlayer.DisplayRole() + $" - {topAssistsPlayer.Assists} assists"
                : "No data";

            YoungestPlayerTextBlock.Text = youngestPlayer != null
                ? youngestPlayer.DisplayRole()
                : "No data";

            MostExperiencedCoachTextBlock.Text = mostExperiencedCoach != null
                ? mostExperiencedCoach.DisplayRole()
                : "No data";

            OldestCoachTextBlock.Text = oldestCoach != null
                ? oldestCoach.DisplayRole()
                : "No data";

            PlayerWithHighestGoalRateTextBlock.Text = playerWithHighestGoalRate != null
                ? playerWithHighestGoalRate.DisplayRole() + $" - {(double)playerWithHighestGoalRate.Goals / playerWithHighestGoalRate.MatchesPlayed:F2} goals per game"
                : "No data";

            AveragePlayerAgeTextBlock.Text = $"{averagePlayerAge:F2} years old";
            TotalGoalsTextBlock.Text = $"{totalGoals}";
            TotalAssistsTextBlock.Text = $"{totalAssists}";
            AveragePlayerHeightTextBlock.Text = $"{averagePlayerHeight:F2} cm";
            PlayerWithMostMatchesTextBlock.Text = playerWithMostMatches != null
                ? playerWithMostMatches.DisplayRole() + $" - {playerWithMostMatches.MatchesPlayed} matches"
                : "No data";
            TotalNumberOfPlayersTextBlock.Text = $"{totalPlayers}";
            TotalNumberOfCoachesTextBlock.Text = $"{totalCoachs}";

        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            Owner?.Show();
            Close();
        }
    }
}
