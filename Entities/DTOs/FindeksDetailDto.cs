using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class FindeksDetailDto
    {
        public int FindeksId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int FindeksScore { get; set; }
    }
}
