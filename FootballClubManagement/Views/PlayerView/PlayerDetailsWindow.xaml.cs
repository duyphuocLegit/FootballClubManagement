using System.Windows;
using FootballClubManagement.Models;
using FootballClubManagement.Services;
using MahApps.Metro.Controls;

namespace FootballClubManagement.Views.PlayerView
{
    public partial class PlayerDetailsWindow : MetroWindow
    {
        private readonly IDataService _dataService;
        private readonly Player _player;

        public PlayerDetailsWindow(Player player)
        {
            InitializeComponent();
            _dataService = new DataService();
            _player = player ?? new Player();
            BindPlayerDetails();
        }

        private void BindPlayerDetails()
        {
            NameTextBox.Text = _player.Name;
            AgeTextBox.Text = _player.Age.ToString();
            HeightTextBox.Text = _player.Height.ToString();
            NationalityTextBox.Text = _player.Nationality;
            PositionTextBox.Text = _player.Position;
            NumberTextBox.Text = _player.Number.ToString();
            GoalsTextBox.Text = _player.Goals.ToString();
            AssistsTextBox.Text = _player.Assists.ToString();
            MatchesPlayedTextBox.Text = _player.MatchesPlayed.ToString();
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            Owner?.Show();
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AgeTextBox.Text, out int age) &&
                int.TryParse(HeightTextBox.Text, out int height) &&
                int.TryParse(NumberTextBox.Text, out int number) &&
                int.TryParse(GoalsTextBox.Text, out int goals) &&
                int.TryParse(AssistsTextBox.Text, out int assists) &&
                int.TryParse(MatchesPlayedTextBox.Text, out int matchesPlayed))
            {
                _player.Name = NameTextBox.Text;
                _player.Age = age;
                _player.Height = height;
                _player.Nationality = NationalityTextBox.Text;
                _player.Position = PositionTextBox.Text.ToUpper();
                _player.Number = number;
                _player.Goals = goals;
                _player.Assists = assists;
                _player.MatchesPlayed = matchesPlayed;

                _dataService.UpdatePlayer(_player);
                MessageBox.Show("Player details have been updated!");

                if (Owner is PlayerManagementWindow playerManagementWindow)
                {
                    playerManagementWindow.LoadPlayers();
                }
                Owner?.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure to delete this player?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _dataService.DeletePlayer(_player.Id);
                MessageBox.Show("Player has been deleted!");

                if (Owner is PlayerManagementWindow playerManagementWindow)
                {
                    playerManagementWindow.LoadPlayers();
                }
                Owner?.Show();
                Close();
            }
        }
    }
}
