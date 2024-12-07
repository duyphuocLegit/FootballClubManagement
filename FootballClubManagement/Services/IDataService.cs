using FootballClubManagement.Models;
using System.Collections.Generic;

namespace FootballClubManagement.Services
{
    public interface IDataService
    {
        // Phương thức quản lý Players
        void AddPlayer(Player player);
        List<Player> GetAllPlayers();
        void UpdatePlayer(Player player);
        void DeletePlayer(int playerId);

        // Phương thức quản lý Coaches
        void AddCoach(Coach coach);
        List<Coach> GetAllCoaches();
        //void UpdateCoach(Coach coach);
        void DeleteCoach(int coachId);
    }
}
