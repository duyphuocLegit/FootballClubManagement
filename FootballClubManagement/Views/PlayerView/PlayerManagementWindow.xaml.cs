using System.Windows;
using FootballClubManagement.Models;
using FootballClubManagement.Services;
using MahApps.Metro.Controls;

namespace FootballClubManagement.Views.PlayerView
{
    public partial class PlayerManagementWindow : MetroWindow
    {
        private readonly IDataService _dataService;

        public PlayerManagementWindow()
        {
            InitializeComponent();
            _dataService = new DataService();
            LoadPlayers();
        }

        public void LoadPlayers()
        {
            var players = _dataService.GetAllPlayers();
            PlayersDataGrid.ItemsSource = players;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addPlayerDialog = new AddPlayerDialog();
            addPlayerDialog.Owner = this; // Set the owner to the current window
            addPlayerDialog.ShowDialog();
            LoadPlayers(); // Refresh the player list after adding a new player
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            Owner?.Show(); // Show the owner window when this window is closed
            Close(); // Close the current window
        }

        private void PlayersDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PlayersDataGrid.SelectedItem is Player selectedPlayer)
            {
                var playerDetailsWindow = new PlayerDetailsWindow(selectedPlayer);
                playerDetailsWindow.Owner = this; // Set the owner to the current window
                playerDetailsWindow.Show();
                Hide(); // Hide the current window instead of closing it
            }
        }
    }
}
