using System;

namespace GridComponent.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Score { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get { return DateTime.UtcNow.Subtract(BirthDate).Days / 365; }
        }
    }
}