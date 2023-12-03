using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             where c.BrandId == brandId && c.ColorId == colorId
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 MinFindeksScore = c.MinFindeksScore,
                                 ImagePath = (from ci in context.CarImages where c.CarId == ci.CarId select ci.ImagePath).FirstOrDefault()!
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.BrandId
                             join co in context.Colors
                                 on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = c.BrandId,
                                 BrandName = b.BrandName,
                                 ColorId = c.ColorId,
                                 ColorName = co.ColorName,
                                 MinFindeksScore = c.MinFindeksScore,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from ci in context.CarImages where c.CarId == ci.CarId select ci.ImagePath).FirstOrDefault()!
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();

            }
        }
      
    }
}
