using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;

namespace Hyper_Store.Application.Services.Common.Queries.GetCategory
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IApplicationDbContext _db;
        public GetCategoryService(IApplicationDbContext db)
        {
            _db = db;
        }


        public ResultDto<List<CategoryDto>> Execute()
        {
            var category = _db.Categories.Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new CategoryDto
                {
                    CatId = p.Id,
                    CategoryName = p.Name
                }).ToList();

            return new ResultDto<List<CategoryDto>>()
            {
                Data = category,
                IsSuccess = true
            };
        }
    }
}
