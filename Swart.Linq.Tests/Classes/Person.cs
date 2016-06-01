using System;

namespace Swart.Linq.Tests.Classes
{
    public class Person
    {
        public Name PersonName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int GetAge()
        {
            return (DateTime.Now.Year - DateOfBirth.Year);
        }

        public Name GetName()
        {
            return PersonName;
        }
    }
}
