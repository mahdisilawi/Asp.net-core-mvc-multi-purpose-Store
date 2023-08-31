using Hyper_Store.Application.Services.Common.Queries.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetCategoryService _categoryService;
        public Search(IGetCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _categoryService.Execute().Data);
        }
    }
}
