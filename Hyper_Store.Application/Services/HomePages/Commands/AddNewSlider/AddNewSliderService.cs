using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Application.Services.Products.Commands.AddNewProduct;
using Hyper_Store.Common.Dto;
using Hyper_Store.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Hyper_Store.Application.Services.HomePages.Commands.AddNewSlider
{
    public class AddNewSliderService : IAddNewSliderService
    {
        private readonly IApplicationDbContext _db;
        private readonly IHostingEnvironment _environment;
        public AddNewSliderService(IApplicationDbContext db, IHostingEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        public ResultDto Execute(IFormFile file, string link)
        {
            var resultUpload = UploadFile(file);


            Slider slider = new Slider()
            {
                Link = link,
                Src = resultUpload.FileNameAddress,
            };
            _db.Sliders.Add(slider);
            _db.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true
            };
        }

        //Uploading file method
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
    
}
