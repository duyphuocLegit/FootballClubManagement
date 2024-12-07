using Microsoft.Data.Sqlite;
using FootballClubManagement.Models;
using System;
using System.Collections.Generic;

namespace FootballClubManagement.Services
{
    public class DataService : IDataService
    {
        private const string ConnectionString = "Data Source=Database/database.db";

        // Player Service
        public void AddPlayer(Player player)
        {
            using var connection = new SqliteConnection(ConnectionString);
            {
                connection.Open();
                string sql = @"
                    INSERT INTO Players (Name, Age, Height, Nationality, Position, Number)
                    VALUES (@Name, @Age, @Height, @Nationality, @Position, @Number);";

                using var command = new SqliteCommand(sql, connection);
                {
                    command.Parameters.AddWithValue("@Name", player.Name);
                    command.Parameters.AddWithValue("@Age", player.Age);
                    command.Parameters.AddWithValue("@Height", player.Height);
                    command.Parameters.AddWithValue("@Nationality", player.Nationality);
                    command.Parameters.AddWithValue("@Position", player.Position);
                    command.Parameters.AddWithValue("@Number", player.Number);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Player> GetAllPlayers()
        {
            var players = new List<Player>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Players;";

                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var player = new Player
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Height = Convert.ToInt32(reader["Height"]),
                            Nationality = reader["Nationality"].ToString(),
                            Position = reader["Position"].ToString(),
                            Number = Convert.ToInt32(reader["Number"]),
                            Goals = Convert.ToInt32(reader["Goals"]),
                            Assists = Convert.ToInt32(reader["Assists"]),
                            MatchesPlayed = Convert.ToInt32(reader["MatchesPlayed"])
                        };
                        players.Add(player);
                    }
                }
            }

            return players;
        }

        public void UpdatePlayer(Player player)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string sql = @"
                UPDATE Players
                SET Name = @Name, Age = @Age, Height = @Height,
                    Nationality = @Nationality, Position = @Position, Number = @Number,
                    Goals = @Goals, Assists = @Assists, MatchesPlayed = @MatchesPlayed
                WHERE Id = @Id;";

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", player.Id);
            command.Parameters.AddWithValue("@Name", player.Name);
            command.Parameters.AddWithValue("@Age", player.Age);
            command.Parameters.AddWithValue("@Height", player.Height);
            command.Parameters.AddWithValue("@Nationality", player.Nationality);
            command.Parameters.AddWithValue("@Position", player.Position);
            command.Parameters.AddWithValue("@Number", player.Number);
            command.Parameters.AddWithValue("@Goals", player.Goals);
            command.Parameters.AddWithValue("@Assists", player.Assists);
            command.Parameters.AddWithValue("@MatchesPlayed", player.MatchesPlayed);

            command.ExecuteNonQuery();
        }

        public void DeletePlayer(int playerId)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string sql = "DELETE FROM Players WHERE Id = @Id;";

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", playerId);
            command.ExecuteNonQuery();
        }



        //Coach Service
        public void AddCoach(Coach coach)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string sql = @"
                INSERT INTO Coaches (Name, Age, Height, Nationality, Experience, CoachingRole)
                VALUES (@Name, @Age, @Height, @Nationality, @Experience, @CoachingRole);";

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", coach.Name);
            command.Parameters.AddWithValue("@Age", coach.Age);
            command.Parameters.AddWithValue("@Height", coach.Height);
            command.Parameters.AddWithValue("@Nationality", coach.Nationality);
            command.Parameters.AddWithValue("@Experience", coach.Experience);
            command.Parameters.AddWithValue("@CoachingRole", coach.CoachingRole);

            command.ExecuteNonQuery();
        }

        public List<Coach> GetAllCoaches()
        {
            var coaches = new List<Coach>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM Coaches;";

            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var coach = new Coach
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Age = Convert.ToInt32(reader["Age"]),
                    Height = Convert.ToInt32(reader["Height"]),
                    Nationality = reader["Nationality"].ToString(),
                    Experience = Convert.ToInt32(reader["Experience"]),
                    CoachingRole = reader["CoachingRole"].ToString(),
                };
                coaches.Add(coach);
            }

            return coaches;
        }

        //public void UpdateCoach(Coach coach)
        //{
        //    using var connection = new SqliteConnection(ConnectionString);
        //    connection.Open();
        //    string sql = @"
        //        UPDATE Coaches
        //        SET Name = @Name, Age = @Age, Height = @Height, Nationality = @Nationality, 
        //            Experience = @Experience, CoachingRole = @CoachingRole
        //        WHERE Id = @Id;";

        //    using var command = new SqliteCommand(sql, connection);
        //    command.Parameters.AddWithValue("@Id", coach.Id);
        //    command.Parameters.AddWithValue("@Name", coach.Name);
        //    command.Parameters.AddWithValue("@Age", coach.Age);
        //    command.Parameters.AddWithValue("@Height", coach.Height);
        //    command.Parameters.AddWithValue("@Nationality", coach.Nationality);
        //    command.Parameters.AddWithValue("@Experience", coach.Experience);
        //    command.Parameters.AddWithValue("@CoachingRole", coach.CoachingRole);

        //    command.ExecuteNonQuery();
        //}

        public void DeleteCoach(int coachId)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string sql = "DELETE FROM Coaches WHERE Id = @Id;";

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", coachId);
            command.ExecuteNonQuery();
        }
    }
}
