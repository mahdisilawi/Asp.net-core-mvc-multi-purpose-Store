using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Store.Application.Services.Common.Queries.GetMenuItem
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IApplicationDbContext _db;
        public GetMenuItemService(IApplicationDbContext db)
        {
            _db = db;
        }

        public ResultDto<List<MenuItemDto>> Execute()
        {
            var category = _db.Categories
                .Include(p => p.SubCategories)
                .Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new MenuItemDto
                {
                    CatId = p.Id,
                    Name = p.Name,
                    Child = p.SubCategories.ToList().Select(child => new MenuItemDto
                    {
                        CatId = child.Id,
                        Name = child.Name
                    }).ToList(),
                }).ToList();

            return new ResultDto<List<MenuItemDto>>()
            {
                Data = category,
                IsSuccess = true
            };
        }
    }
}
