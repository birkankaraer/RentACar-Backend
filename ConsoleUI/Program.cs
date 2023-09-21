using Business.Concrete;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BrandIdTest();
            //BrandTest();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
            

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void BrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var brandid in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(brandid.ModelName + "" + brandid.BrandId);
            }
        }
    }
}