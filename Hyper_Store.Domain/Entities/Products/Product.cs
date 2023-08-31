using Hyper_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }

        //تعداد بازدید از محصول
        public int ViewCount { get; set; }

        //Relation Product <=> ProductFeatures
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set;}

        //Relation Product <=> ProductImages
        public virtual ICollection<ProductImages> ProductImages { get; set; }

        //Relation Product <=> Category
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }

    }
}
