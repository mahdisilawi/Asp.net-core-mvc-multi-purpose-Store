using Hyper_Store.Domain.Entities.Commons;

namespace Hyper_Store.Domain.Entities.Products
{
    public class ProductFeatures :BaseEntity
    {
        //Relation ProductFeatures <=> Product
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }


        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
