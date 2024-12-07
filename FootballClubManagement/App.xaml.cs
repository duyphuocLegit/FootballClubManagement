using FootballClubManagement.Database;
using System;
using System.Windows;

namespace FootballClubManagement
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                // Initialize the database
                DatabaseInitializer.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize the database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
