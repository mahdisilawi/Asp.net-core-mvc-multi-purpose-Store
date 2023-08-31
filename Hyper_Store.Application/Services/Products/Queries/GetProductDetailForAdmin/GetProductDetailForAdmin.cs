using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;
using Hyper_Store.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Store.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public class GetProductDetailForAdmin : IGetProductDetailForAdmin
    {
        private readonly IApplicationDbContext _db;
        public GetProductDetailForAdmin(IApplicationDbContext db)
        {
            _db = db;
        }
        public ResultDto<ProductDetailForAdminDto> Execute(long id)
        {
            var product = _db.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.SubCategories)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return new ResultDto<ProductDetailForAdminDto>()
            {
               Data =  new ProductDetailForAdminDto()
                {
                    Brand = product.Brand,
                   Category = GetCategory(product.Category),
                   Description = product.Description,
                   Displayed = product.Displayed,
                   Id = product.Id,
                   Inventory = product.Inventory,
                   Name = product.Name,
                   Price = product.Price,
                   Features = product.ProductFeatures.ToList().Select(p => new ProductDetailFeaturesDto
                   {
                       Id = p.Id,
                       DisplayName = p.DisplayName,
                       Value = p.Value
                   }).ToList(),
                   Images = product.ProductImages.ToList().Select(p => new ProductDetailImagesDto
                   {
                       Id = p.Id,
                       Src = p.Src,
                   }).ToList(),
               },
               IsSuccess = true,
               Message = ""
            };
        }

        //method that get category 
        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }
}
