﻿using System.Windows;
using FootballClubManagement.Views.PlayerView;
using FootballClubManagement.Views.CoachView;
using FootballClubManagement.Views;
using MahApps.Metro.Controls;
using System;

namespace FootballClubManagement
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Navigate to Player Management Window
        private void ManagePlayers_Click(object sender, RoutedEventArgs e)
        {
            var playerWindow = new PlayerManagementWindow();
            playerWindow.Owner = this; // Set the owner to the main window
            playerWindow.Closed += (s, args) => Show(); // Show the main window when the child window is closed
            playerWindow.Show();
            Hide(); // Hide the main window instead of closing it
        }

        // Navigate to Coach Management Window
        private void ManageCoaches_Click(object sender, RoutedEventArgs e)
        {
            var coachWindow = new CoachManagementWindow();
            coachWindow.Owner = this; // Set the owner to the main window
            coachWindow.Closed += (s, args) => Show(); // Show the main window when the child window is closed
            coachWindow.Show();
            Hide(); // Hide the main window instead of closing it
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            var statisticWindow = new StatisticWindow();
            statisticWindow.Owner = this; // Set the owner to the main window
            statisticWindow.Closed += (s, args) => Show(); // Show the main window when the child window is closed
            statisticWindow.Show();
            Hide(); // Hide the main window instead of closing it
        }
    }
}