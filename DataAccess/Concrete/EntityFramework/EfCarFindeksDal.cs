using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarFindeksDal : EfEntityRepositoryBase<CarFindeks, RentACarContext>, ICarFindeksDal
    {
        public List<CarFindeksDetailDto> GetFindeksDetail(Expression<Func<CarFindeksDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.CarFindeks
                             join car in context.Cars on c.CarId equals car.CarId
                             select new CarFindeksDetailDto()
                             {
                                 CarId = car.CarId,
                                 FindeksScore = c.FindeksScore,
                                 FindeksId = c.Id
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
