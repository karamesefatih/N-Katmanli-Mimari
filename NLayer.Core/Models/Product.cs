using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Product : BaseEntity
    {
        //nullable chek kapama
        /*  public Product(string name)
          {
              Name = name ?? throw new ArgumentNullException(nameof(Name));
          }
        */
        public string Name { get; set; }
        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        // [ForeignKey("Category_Id")]

        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }
    }
}
