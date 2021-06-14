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
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(1, 9999.99)]
        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public string ImageURL { get; set; }
    }
}
