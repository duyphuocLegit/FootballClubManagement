using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace FootballClubManagement.Database
{
    public static class DatabaseInitializer
    {
        private const string DatabaseFileName = "Database/database.db";

        public static void Initialize()
        {
            // Ensure the "Database" directory exists
            string directory = Path.GetDirectoryName(DatabaseFileName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine($"Directory '{directory}' created.");
            }

            // Connection string to the database
            string connectionString = $"Data Source={DatabaseFileName}";

            // Create database and tables
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Create Players table
                string createPlayersTable = @"
                    CREATE TABLE IF NOT EXISTS Players (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Age INTEGER NOT NULL,
                        Height INTEGER NOT NULL,
                        Nationality TEXT NOT NULL,
                        Position TEXT NOT NULL,
                        Number INTEGER NOT NULL,
                        Goals INTEGER DEFAULT 0,
                        Assists INTEGER DEFAULT 0,
                        MatchesPlayed INTEGER DEFAULT 0
                    );";

                // Create Coaches table
                string createCoachesTable = @"
                     CREATE TABLE IF NOT EXISTS Coaches (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Age INTEGER NOT NULL,
                        Height INTEGER NOT NULL,
                        Nationality TEXT NOT NULL,
                        Experience INTEGER NOT NULL,
                        CoachingRole TEXT NOT NULL
                    );";

                ExecuteNonQuery(connection, createPlayersTable);
                ExecuteNonQuery(connection, createCoachesTable);

                Console.WriteLine("Database initialized with Microsoft.Data.Sqlite.");
            }
        }

        private static void ExecuteNonQuery(SqliteConnection connection, string sql)
        {
            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
