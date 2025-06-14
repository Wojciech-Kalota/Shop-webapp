using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.Now;
    }
}
