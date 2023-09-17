using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
