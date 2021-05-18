using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerService = new CustomerManager();
            customerService.MessageSenderBase = new SmsSender();
            customerService.Add();

        }
    }

   abstract  class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }
         public abstract void Send(Body body);
      
   }
    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }

    }
    class MailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender",body.Title);
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);

        }
    }

    class CustomerManager : ICustomerService
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void Add()
        {
            MessageSenderBase.Send(new Body { Title = "Customer Add", Text = "Customer add success" });
            Console.WriteLine("Customer added!");
        }
    }
    interface  ICustomerService
    {
        void Add();

    }
}
