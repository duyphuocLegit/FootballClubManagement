using FootballClubManagement.Models;
using FootballClubManagement.Services;
using System.Windows;
using MahApps.Metro.Controls;
namespace FootballClubManagement.Views.CoachView
{
    public partial class AddCoachDialog : MetroWindow
    {
        private readonly IDataService _dataService;

        public AddCoachDialog()
        {
            InitializeComponent();
            _dataService = new DataService();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AgeTextBox.Text, out int age) &&
                int.TryParse(HeightTextBox.Text, out int height) &&
                int.TryParse(ExperienceTextBox.Text, out int experience))
            {
                var coach = new Coach
                {
                    Name = NameTextBox.Text,
                    Age = age,
                    Height = height,
                    Nationality = NationalityTextBox.Text,
                    Experience = experience,
                    CoachingRole = CoachingRoleTextBox.Text

                };
                _dataService.AddCoach(coach);
                MessageBox.Show("Coach has been added!");

                var CoachManagementWindow = new CoachManagementWindow();
                CoachManagementWindow.LoadCoaches();
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