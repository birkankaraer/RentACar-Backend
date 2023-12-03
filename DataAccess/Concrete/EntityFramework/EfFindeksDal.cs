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
    public class EfFindeksDal : EfEntityRepositoryBase<Findeks, RentACarContext>, IFindeksDal
    {
        public List<FindeksDetailDto> GetFindeksDetail(Expression<Func<FindeksDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from f in context.Findeks
                             join u in context.Users on f.UserId equals u.Id
                             select new FindeksDetailDto()
                             {
                                 FindeksId = f.Id,
                                 UserId = u.Id,
                                 UserName = u.FirstName + " " + u.LastName,
                                 FindeksScore = f.FindeksScore

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
