using System;
using System.Collections.Generic;

namespace stay_classy_cs
{
    class Program
    {
        public class Address
        {
            public string StreetAddress { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }

            public string PrintableAddress()
            {
               return $"{this.StreetAddress}\n{this.City}, {this.State} {this.PostalCode}\n{this.Country}"; 
            }
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Address ShippingAddress { get; set; }
            public string FullName()
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }

        public class Company
        {
            public string Name { get; set; }
            public Address ShippingAddress { get; set; }
        }

        static void PrintShippingInfo(string name, Address address)
        {
            Console.WriteLine(name);
            Console.WriteLine(address.PrintableAddress());
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Person JohnDoe = new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                ShippingAddress = new Address() { StreetAddress = "123 Sesame St", City = "New York", State = "NY", PostalCode = "10001", Country = "USA"}
            };

            Company Acme = new Company()
            {
                Name = "Acme, Inc.",
                ShippingAddress = new Address() { StreetAddress = "123 Main St", City = "Anytown", State = "PA", PostalCode = "12001", Country = "USA" }
            };

            List<Person> people = new List<Person> ();
            List<Company> companies = new List<Company> ();

            people.Add(JohnDoe);
            companies.Add(Acme);

            Console.WriteLine("Personal Directory:");
            people.ForEach((p) => PrintShippingInfo(p.FullName(), p.ShippingAddress));

            Console.WriteLine("Professional Directory:");
            companies.ForEach((c) => PrintShippingInfo(c.Name, c.ShippingAddress));
        }
    }
}
