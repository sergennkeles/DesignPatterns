using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            productDirector.GenerateProduct(builder);

            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.DiscountApplied);

        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }

    }

    abstract class ProductBuilder
    {

        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();

    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel viewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            viewModel.DiscountedPrice = viewModel.UnitPrice * (decimal)0.90;
            viewModel.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return viewModel;
        }

        public override void GetProductData()
        {
            viewModel.Id = 1;
            viewModel.ProductName = "Asus";
            viewModel.UnitPrice = 130000;
            viewModel.CategoryName = "Bilgisayar";
            

        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel viewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            viewModel.DiscountedPrice = viewModel.UnitPrice * (decimal)0.70;
            viewModel.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return viewModel;
        }

        public override void GetProductData()
        {
            viewModel.Id = 1;
            viewModel.ProductName = "Apple,";
            viewModel.UnitPrice = 130000;
            viewModel.CategoryName = "Cep Telefonu";
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
