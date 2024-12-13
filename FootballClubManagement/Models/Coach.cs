namespace FootballClubManagement.Models
{
    public class Coach : Person
    {
        public int Experience { get; set; }
        public string CoachingRole { get; set; }
        public Coach() { }

        public Coach(string name, int age, int height, string nationality, int experience, string coachingRole)
            : base(name, age, height, nationality)
        {
            Experience = experience;
            CoachingRole = coachingRole;
        }

        public override string DisplayRole()
        {
            return $"{Name}, {Age} years old, has {Experience} years of experience";
        }
    }
}
