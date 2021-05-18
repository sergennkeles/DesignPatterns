using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new IndividualCustomer();
            customerManager.Save();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class CoorporateCustomer : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("CoorporateCustomer credit calculated!");
        }
    }

    class IndividualCustomer : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("IndividualCustomer credit calculated!");

        }
    }

    interface ICustomerService
    {
        void Save();
    }
    class CustomerManager : ICustomerService
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void Save()
        {
           
            Console.WriteLine("Customer Credit Business rules");
            CreditCalculatorBase.Calculate();
        }
    }
}
