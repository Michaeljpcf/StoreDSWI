using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.ComponentModel.DataAnnotations;

namespace StoreDSWI.Entities
{
    public class Product : BaseEntity
    {
        [Range(1,1000000)]
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }
        public string ImageURL { get; set; }
    }
}
