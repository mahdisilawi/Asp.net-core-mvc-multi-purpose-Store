using Hyper_Store.Application.Interfaces.FacadPatterns;
using Hyper_Store.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index(Ordering ordering,string searchKey, int pageSize, long? catId = null, int page = 1)
        {
            return View(_productFacad.GetProductForSiteService.Execute(ordering,searchKey, page, pageSize, catId).Data);
        }

        public IActionResult Detail(long id)
        {
            return View(_productFacad.GetProductDetailForSiteService.Execute(id).Data);
        }
    }
}
