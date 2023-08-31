using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;
using Hyper_Store.Domain.Entities.Products;

namespace Hyper_Store.Application.Services.Products.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IApplicationDbContext _db;
        public AddNewCategoryService(IApplicationDbContext db)
        {
            _db = db;
        }

        public ResultDto Execute(long? ParentId, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمایید",
                };
            }

            Category category = new Category()
            {
                Name = Name,
                ParentCategory = GetParent(ParentId)
            };
            _db.Categories.Add(category);
            _db.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد",
            };
        }

        private Category GetParent(long? ParentId)
        {
            return _db.Categories.Find(ParentId);
        }
    }
}
