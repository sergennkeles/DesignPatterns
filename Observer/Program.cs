using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            CustomerObserver customerObserver = new CustomerObserver();
            productManager.Attach(customerObserver);
            productManager.Attach(new  EmployeeObserver());
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();
        }
    }

    interface IProductService
    {
        void UpdatePrice();
    }

    class ProductManager : IProductService
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product Price changed!");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update("Ürün fiyatı düştü.");
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update(string message);
    }

    class CustomerObserver : Observer
    {
        public override void Update(string message)
        {
            Console.WriteLine("Message to customer: "+message);
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update(string message)
        {
            Console.WriteLine("Message to employee: " + message);
        }
    }
}
