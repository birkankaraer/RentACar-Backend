using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    internal interface IRentalService
    {
        List<Rental> GetAll();
        
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(Rental rental);
    }
}
