using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Test
{
    class Person : IEquatable<Person>
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
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Person);
        }
        public bool Equals(Person other)
        {
            if (other == null)
                return false;
            return
                (
                object.ReferenceEquals(this.FirstName, other.FirstName) ||
                this.FirstName != null &&
                this.FirstName.Equals(other.FirstName)
                ) &&
                (
                object.ReferenceEquals(this.LastName, other.LastName) ||
                this.LastName != null &&
                this.LastName.Equals(other.LastName)
                ) &&
                (
                object.ReferenceEquals(this.Address, other.Address) ||
                this.Address != null &&
                this.Address.Equals(other.Address)
                );
        }
    }
    class Address : IEquatable<Address>
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
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Address);
        }
        public bool Equals(Address other)
        {
            if (other == null)
                return false;
            return this.House.Equals(other.House) &&
                (
                object.ReferenceEquals(this.Street, other.Street) ||
                this.Street != null &&
                this.Street.Equals(other.Street)
                ) &&
                (
                object.ReferenceEquals(this.City, other.City) ||
                this.City != null &&
                this.City.Equals(other.City)
                );
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
           
            if (first.FirstName.Equals(second.FirstName) == false)
            {
                Console.WriteLine("FirstName" + "\t\t" + first.FirstName + "\t\t" + second.FirstName);
            }
            if (first.LastName.Equals(second.LastName) == false)
            {
                Console.WriteLine("LastName" + "\t\t" + first.LastName + "\t\t" + second.LastName);
            }
            if (first.Address.City.Equals(second.Address.City) == false)
            {
                Console.WriteLine("AddressCity" + "\t\t" + first.Address.City + "\t\t" + second.Address.City);
            }
            if (first.Address.Street.Equals(second.Address.Street) == false)
            {
                Console.WriteLine("AddressStreet" + "\t\t" + first.Address.Street + "\t\t" + second.Address.Street);
            }
            if (first.Address.House.Equals(second.Address.House) == false)
            {
                Console.WriteLine("AddressHouse" + "\t\t" + first.Address.House + "\t\t" + second.Address.House);
            }

            Console.ReadLine();
        }
    }
}
