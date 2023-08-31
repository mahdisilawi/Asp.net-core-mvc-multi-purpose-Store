using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common;
using Hyper_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Store.Application.Services.Products.Queries.GetProductForSite
{
    public class GetProductForSiteService : IGetProductForSiteService
    {

        private readonly IApplicationDbContext _context;
        public GetProductForSiteService(IApplicationDbContext context)
        {
            _context = context;
        }
        public ResultDto<ResultProductForSiteDto> Execute(Ordering ordering,string searchKey, int Page, int pageSize, long? catId)
        {
            pageSize = 20;
            int totalRow = 0;
            var productQuery = _context.Products
                .Include(p => p.ProductImages).AsQueryable();

            if (catId != null)
            {
                productQuery = productQuery.Where(p => p.CategoryId == catId || p.Category.ParentCategoryId == catId).AsQueryable();
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                productQuery = productQuery.Where(p => p.Name.Contains(searchKey) || p.Brand.Contains(searchKey)).AsQueryable();
            }

            switch (ordering)
            {
                case Ordering.NotOrder:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    productQuery = productQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.Bestselling:
                    break;
                case Ordering.MostPopular:
                    break;
                case Ordering.theNewest:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    productQuery = productQuery.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.theMostExpensive:
                    productQuery = productQuery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
                default:
                    break;
            }

            var product = productQuery.ToPaged(Page, pageSize, out totalRow);

            Random rd = new Random();
            return new ResultDto<ResultProductForSiteDto>
            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = totalRow,
                    Products = product.Select(p => new ProductForSiteDto
                    {
                        Id = p.Id,
                        Star = rd.Next(1, 5),
                        Title = p.Name,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                        Price = p.Price
                    }).ToList(),
                },
                IsSuccess = true,
            };
        }
    }

}
