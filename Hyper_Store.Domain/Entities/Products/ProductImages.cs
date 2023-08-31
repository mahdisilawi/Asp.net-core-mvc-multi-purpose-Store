using Hyper_Store.Domain.Entities.Commons;

namespace Hyper_Store.Domain.Entities.Products
{
    public class ProductImages : BaseEntity
    {
        //Relation ProductImages <=> Product
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }

        public string Src { get; set;}
    }
}
