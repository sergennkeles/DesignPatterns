using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Brand = "Honda", Model = "Civic", HirePrice = 1000 };
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscontPercentage = 10;

            Console.WriteLine("Personal Car : {0} ", personalCar.HirePrice);
            Console.WriteLine("Special Offer : {0} ", specialOffer.HirePrice);

        }
    }

    abstract class CarBase
    {
        public abstract string Brand { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscontPercentage { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;

        }
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get { return _carBase.HirePrice-(_carBase.HirePrice *DiscontPercentage/100); } set { } }
    }

}
