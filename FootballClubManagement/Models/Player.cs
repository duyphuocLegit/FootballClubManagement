namespace FootballClubManagement.Models
{
    public class Player : Person
    {
        public string Position { get; set; }
        public int Number { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MatchesPlayed { get; set; }
        public Player() { }
        
        public Player(string name, int age, int height, string nationality, string position, int number)
            : base(name, age, height, nationality)
        {
            Position = position;
            Number = number;
            Goals = 0;
            Assists = 0;
            MatchesPlayed = 0;
        }

        public override string DisplayRole()
        {
            return $"{Name}, {Age} years old, pos: {Position}";
        }
    }
}