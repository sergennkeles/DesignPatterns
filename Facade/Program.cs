using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();

            customerManager.Add();
         
        }
    }

    interface ILogger
    {
        public void Log(string message);
    }

    interface ICache
    {
        public void Cache(string cache);
    }

    interface IAuthorize
    {
      public  void Auth(String message);
    }

    class Logging : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged :"+message);
        }
    }

    class Caching : ICache
    {
        public void Cache(string cache)
        {
            Console.WriteLine("Cached :"+cache);
        }
    }

    class Authorize : IAuthorize
    {
        public void Auth(string message)
        {
            Console.WriteLine("Auth : "+message);
        }
    }

    class CustomerManager
    {
        CrossCuttingConcernsFacade crossCutting;
        public CustomerManager()
        {
            crossCutting = new CrossCuttingConcernsFacade();
        }

        public void Add()
        {
            Console.WriteLine("saved to db");
            crossCutting.logger.Log(" Kullanıcı loglandı");
            crossCutting.caching.Cache("Cacheden alındı");
            crossCutting.authorize.Auth("Sergen");
        }
    
    }

    class CrossCuttingConcernsFacade
    {

        public ILogger logger;
        public ICache caching;
        public IAuthorize authorize;
        public CrossCuttingConcernsFacade()
        {
            logger = new Logging();
            caching = new Caching();
            authorize = new Authorize();

        }
    }
}
