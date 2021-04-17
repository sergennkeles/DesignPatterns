using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer {Id=1,FirstName="Sergen",LastName="Keleş",City="İstanbul" };

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Simge";
            Console.WriteLine("customer1'deki veri "+customer1.FirstName+ " " +customer1.LastName);
            Console.WriteLine("customer2'deki veri " + customer2.FirstName + " " + customer2.LastName);

        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer: Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal  Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
