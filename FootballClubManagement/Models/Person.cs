using System;

namespace FootballClubManagement.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string Nationality { get; set; }

        public Person() { }
        protected Person(string name, int age, int height, string nationality)
        {
            Name = name;
            Age = age;
            Height = height;
            Nationality = nationality;
        }

        public abstract string DisplayRole();
    }
}
