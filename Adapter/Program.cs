using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());

            productManager.Save();
        }
    }

    interface ILogging
    {
        void Log(string message);
    }

    class SkLogger : ILogging
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged with SkLogger: "+message);
        }
    }

    class Log4Net
    {
        public void Log4NetMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net: "+message );
        }
    }

    class Log4NetAdapter : ILogging
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.Log4NetMessage(message);
        }
    }



    class ProductManager
    {
        ILogging _logging;

        public ProductManager(ILogging logging)
        {
            _logging = logging;
        }

        public void Save()
        {
            Console.WriteLine("Saved to db");
            _logging.Log("Ürün loglandı");
        }
    }


}
