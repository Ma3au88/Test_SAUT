using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Person() { }
        public Person(string FirstName, string LastName, Address Address)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
        }
        public override string ToString()
        {
            return String.Format("\nFirstName: {0}\nLastName: {1}\n{2}",
                this.FirstName, this.LastName, this.Address);
        }
    }
    class PersonComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            string.Compare(first.FirstName, second.FirstName);
            string.Compare(first.LastName, second.LastName);
        }
    }
    class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public Address() { }
        public Address(string City, string Street, int House)
        {
            this.City = City;
            this.Street = Street;
            this.House = House;
        }
        public override string ToString()
        {
            return String.Format("Address.City: {0}\nAddress.Street: {1}\nAddress.House: {2}",
                this.City, this.Street, this.House);
        }
    }
    class AddressComparer : IComparer<Address>
    {
        public int Compare(Address first, Address second)
        {
            string.Compare(first.City, second.City);
            string.Compare(first.Street, second.Street);
            if (first.House != second.House)
                return 1;
            else
                return 0;
        }
    }
    class Program
    {
        static void Main()
        {
            var first =
                new Person
                {
                    FirstName = "Иван",
                    LastName = "Сидоров",
                    Address =
                    new Address
                    {
                        City = "Екатеринбург",
                        Street = "Малышева",
                        House = 4
                    }
                };
            var second =
                new Person
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Address =
                    new Address
                    {
                        City = "Екатеринбург",
                        Street = "Ленина",
                        House = 1
                    }
                };

            //var differences = comparer.Compare<Person>(first, second);
            Console.WriteLine("Путь\t\t First\t\t Second");
            Console.WriteLine(first);
            Console.WriteLine(second);

            Console.ReadLine();
        }
    }
}