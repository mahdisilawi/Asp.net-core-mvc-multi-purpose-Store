using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Store.Application.Services.Products.Queries.GetProductDetailForSite
{
    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IApplicationDbContext _context;
        public GetProductDetailForSiteService(IApplicationDbContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailForSiteDto> Execute(long Id)
        {
            var Product = _context.Products
                .Include(p=> p.Category)
                .ThenInclude(p=>p.ParentCategory)
                .Include(p=>p.ProductImages)
                .Include(p=> p.ProductFeatures)
                .Where(p=> p.Id==Id).FirstOrDefault();

            if(Product == null)
            {
                throw new Exception("Product Not Found.....");
            }

            Product.ViewCount++;
            _context.SaveChanges();

            return new ResultDto<ProductDetailForSiteDto>()
            {
                Data = new ProductDetailForSiteDto
                {
                    Brand = Product.Brand,
                    Category = $"{Product.Category.ParentCategory.Name}  - {Product.Category.Name}",
                    Description = Product.Description,
                    Id = Product.Id,
                    Price = Product.Price,
                    Title = Product.Name,
                    Images = Product.ProductImages.Select(p => p.Src).ToList(),
                    Features = Product.ProductFeatures.Select(p => new ProductDetailForSite_FeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),

                },
                IsSuccess = true,
            };

        }
    }




}
