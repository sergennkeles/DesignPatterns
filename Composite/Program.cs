using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee people1 = new Employee { Name = "Sergen KELEŞ" };
            Employee people2 = new Employee { Name = "Atiba Hutchinson" };
        
            people1.AddSubordinate(people2);

            Employee people3 = new Employee { Name = "Vincent Aboubakar" };
            people1.AddSubordinate(people3);

            Employee people4 = new Employee { Name = "Rachid Ghezzal" };
            people2.AddSubordinate(people4);

            Employee people5 = new Employee { Name = "Valentin Rosier" };
            people2.AddSubordinate(people5);

            Employee people6 = new Employee { Name = "Cyle Larin" };
            people3.AddSubordinate(people6);

            Console.WriteLine(people1.Name);
            foreach (Employee manager in people1)
            {
                Console.WriteLine("  {0}",
                manager.Name);

                foreach (Employee employee in manager)
                {
                    Console.WriteLine("   {0}",employee.Name);

                }
            }

        }
    }


    interface IPerson
    {
        string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        public string Name { get; set; }

        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];

        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var item in _subordinates)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
