using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
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
                                 //MinFindexScore = c.MinFindexScore,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 CarImages = ((from ci in context.CarImages
                                               where (c.CarId == ci.CarId)
                                               select new CarImage
                                               {
                                                   CarId = ci.CarImageId,
                                                   CarImageId = ci.CarId,
                                                   Date = ci.Date,
                                                   ImagePath = ci.ImagePath
                                               }).ToList()).Count == 0
                                                    ? new List<CarImage> { new CarImage { CarId = -1, CarImageId = c.CarId, Date = DateTime.Now, ImagePath = "/images/default.jpg" } }
                                                    : (from ci in context.CarImages
                                                       where (c.CarId == ci.CarId)
                                                       select new CarImage
                                                       {
                                                           CarId = ci.CarImageId,
                                                           CarImageId = ci.CarId,
                                                           Date = ci.Date,
                                                           ImagePath = ci.ImagePath
                                                       }).ToList()
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();

            }
        }

        
    }
}
