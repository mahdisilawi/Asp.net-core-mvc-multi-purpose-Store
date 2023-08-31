using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common;
using Hyper_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Store.Application.Services.Products.Queries.GetProductForAdmin
{
    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IApplicationDbContext _db;
        public GetProductForAdminService(IApplicationDbContext db)
        {
            _db = db;
        }
        public ResultDto<ProductForAdminDto> Execute(int page = 1, int pageSize = 20)
        {
            int page_Size = pageSize;
            int page_ = page;

            page_Size = 20;
            page_ = 1;
            int rowsCount = 0;
            var products = _db.Products
                .Include(p => p.Category)
                .ToPaged(page_, page_Size, out rowsCount)
                .Select(p => new ProductListForAdminDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    Price = p.Price,
                    Inventory = p.Inventory,
                    Description = p.Description,
                    Displayed = p.Displayed,
                    Category = p.Category.Name

                }).ToList();

            return new ResultDto<ProductForAdminDto>()
            {
                Data = new ProductForAdminDto()
                {
                    CurrentPage = page_,
                    PageSize = page_Size,
                    RowCount = rowsCount,
                    Products = products
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

}
