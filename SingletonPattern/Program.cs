using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *  SİNGLETON PATTERN DESİGN 
             *  Bir nesne örneğinin sadece bir kere üretilmesini ve bu nesnenin her zaman kullanılmasını öngören desen türüdür.
             *  Her zaman kullanılacak nesnelerin sürekli olarak new'lenmesi maliyetlidir. Bu durumda Singleton design pattern kullanmak daha mantıklıdır.
             *  Singleton design pattern kullanırken dikkatli olmak lazım. Eğer bir kereliğine kullanılacak olan nesnelerde kullanılırsa bu da doğru olmaz.
             *  **/
            var customerManager = CustomerManager.CreateSingletonPattern();

            customerManager.Add();

        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;

        static object _lockObject = new object();
        
        private CustomerManager()
        {

        }

        public static CustomerManager CreateSingletonPattern()
        {
            lock (_lockObject) //defensive programming ile alakalı bir işlem. Örneğin aynı anda 2 istek birden geldiğinde(nadiren olabilir )
                               //2 kez _customerManager oluşturulmasının önüne geçmek için alınan bir önlem. Önce işlemi kilitle sonra _customerManager
                               // oluşturulmuş mu kontrol et ve ardından işleme devam et.

            {
                if (_customerManager==null) // Eğer _customerManager null ise _customerManager'ı new'le değilse _customerManager'ı return et 
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }


       public void Add()
        {
            Console.WriteLine("Added");
        }


    }
}
