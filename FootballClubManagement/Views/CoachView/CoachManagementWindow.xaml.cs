using System;
using System.Windows;
using FootballClubManagement.Models;
using FootballClubManagement.Services;
using MahApps.Metro.Controls;

namespace FootballClubManagement.Views.CoachView
{
    public partial class CoachManagementWindow : MetroWindow
    {
        private readonly IDataService _dataService;

        public CoachManagementWindow()
        {
            InitializeComponent();
            _dataService = new DataService();
            LoadCoaches();
        }

        public void LoadCoaches()
        {
            var coaches = _dataService.GetAllCoaches();
            CoachesDataGrid.ItemsSource = coaches;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addCoachDialog = new AddCoachDialog();
            addCoachDialog.Owner = this; // Set the owner to the current window
            addCoachDialog.ShowDialog();
            LoadCoaches();
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            Owner?.Show(); // Show the owner window when this window is closed
            Close(); // Close the current window
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CoachesDataGrid.SelectedItem is Coach selectedCoach)
            {
                var result = MessageBox.Show("Are you sure to delete this coach?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _dataService.DeleteCoach(selectedCoach.Id);
                    MessageBox.Show("Coach has been deleted!");
                    LoadCoaches();
                }
            }
        }
    }
}
