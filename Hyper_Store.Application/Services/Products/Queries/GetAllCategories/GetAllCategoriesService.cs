using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Store.Application.Services.Products.Queries.GetAllCategories
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IApplicationDbContext _context;

        public GetAllCategoriesService(IApplicationDbContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new AllCategoriesDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory.Name} - {p.Name}",
                }
                ).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = false,
                Message = "",
            };
        }
    }



}
