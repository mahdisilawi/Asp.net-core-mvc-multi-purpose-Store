using Hyper_Store.Application.Services.HomePages.Commands.AddNewHomePageImages;
using Hyper_Store.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImagesController : Controller
    {
        private readonly IAddNewHomePageImagesService _addNewHomePageImagesService;
        public HomePageImagesController(IAddNewHomePageImagesService addNewHomePageImagesService)
        {
            _addNewHomePageImagesService = addNewHomePageImagesService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file, string link, ImageLocation imageLocation)
        {
            _addNewHomePageImagesService.Execute(new RequestAddHomePagesDto
            {
                File = file,
                ImageLocation = imageLocation,
                Link = link,
            });
            return View();
        }

    }
}
