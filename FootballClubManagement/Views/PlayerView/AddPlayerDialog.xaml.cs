using FootballClubManagement.Models;
using FootballClubManagement.Services;
using System.Windows;
using MahApps.Metro.Controls;

namespace FootballClubManagement.Views.PlayerView
{
    public partial class AddPlayerDialog : MetroWindow
    {
        private readonly IDataService _dataService;

        public AddPlayerDialog()
        {
            InitializeComponent();
            _dataService = new DataService();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AgeTextBox.Text, out int age) &&
                int.TryParse(HeightTextBox.Text, out int height) &&
                int.TryParse(NumberTextBox.Text, out int number))
            {
                var player = new Player
                {
                    Name = NameTextBox.Text,
                    Age = age,
                    Height = height,
                    Nationality = NationalityTextBox.Text,
                    Position = PositionTextBox.Text.ToUpper(),
                    Number = number
                };
                _dataService.AddPlayer(player);
                MessageBox.Show("Player has been added");

                // Refresh the player list in the parent window if necessary
                if (Owner is PlayerManagementWindow playerManagementWindow)
                {
                    playerManagementWindow.LoadPlayers();
                }

                Close();
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

