using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Application.Services.Products.Commands.AddNewProduct;
using Hyper_Store.Common.Dto;
using Hyper_Store.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Application.Services.HomePages.Commands.AddNewHomePageImages
{
    public interface IAddNewHomePageImagesService
    {
        ResultDto Execute(RequestAddHomePagesDto request);
    }
    public class AddNewHomePageImagesServicel : IAddNewHomePageImagesService
    {
        private readonly IApplicationDbContext _db;
        private readonly IHostingEnvironment _environment;

        public AddNewHomePageImagesServicel(IApplicationDbContext db, IHostingEnvironment hosting)
        {
            _db = db;
            _environment = hosting;
        }
        public ResultDto Execute(RequestAddHomePagesDto request)
        {
            var resultUpload = UploadFile(request.File);

            HomePageImages homePageImages = new HomePageImages()
            {
                Link = request.Link,
                ImageLocation = request.ImageLocation,
                Src = resultUpload.FileNameAddress
            };

            _db.HomePageImages.Add(homePageImages);
            _db.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true
            };
        }

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

    public class RequestAddHomePagesDto
    {
        public IFormFile File { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
