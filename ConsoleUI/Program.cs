using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var brandid in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(brandid.ModelName + ""+ brandid.BrandId);
            }

        }
    }
}