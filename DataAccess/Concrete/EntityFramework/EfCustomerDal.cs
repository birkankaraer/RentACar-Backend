using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var customerDetail = from c in context.Customers
                                     join u in context.Users
                                     on c.UserId equals u.UserId
                                     select new CustomerDetailDto
                                     {
                                         CompanyName = c.CompanyName,
                                         CustomerId = c.CustomerId,
                                         Email = u.Email,
                                         FirstName = u.FirstName,
                                         LastName = u.LastName
                                     };
                return customerDetail.ToList();



            }
        }
    }
}
