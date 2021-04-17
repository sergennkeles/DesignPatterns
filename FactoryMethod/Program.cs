using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {

           
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new DatabaseLogger();
        }
    }


    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new FileLogger();
        }
    }
    public interface ILogger
    {
        void Log();
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with DatabaseLogger");
        }
    }

    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with FileLogger");
        }
    }

    public class CustomerManager
    {
        public void Add()
        {   //LoggerFactory veya LoggerFactory2 olarak loglama sistemini 2 farklı şekilde kullanabiliriz.
            //Dependency Injection kullanarak da yapabilirdik.
            Console.WriteLine("Added!!!");
            ILogger logger = new LoggerFactory2().CreateLogger(); 
            logger.Log();
        }
    }
}
