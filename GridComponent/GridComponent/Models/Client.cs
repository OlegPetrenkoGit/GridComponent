using System;

namespace GridComponent.Models
{
    public class Client : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get { return DateTime.UtcNow.Subtract(BirthDate).Days / 365; }
        }
    }
}