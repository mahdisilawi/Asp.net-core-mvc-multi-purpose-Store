using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;
using Hyper_Store.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Hyper_Store.Application.Services.Products.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IApplicationDbContext _db;
        private readonly IHostingEnvironment _environment;
        public AddNewProductService(IApplicationDbContext db, IHostingEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        
        public ResultDto Execute(RequestAddNewProductDto request)
        {

            try
            {
                var caregory = _db.Categories.Find(request.CategoryId);

                Product product = new Product()
                {
                    Brand = request.Brand,
                    Name = request.Name,
                    Description = request.Description,
                    Inventory = request.Inventory,
                    Price = request.Price,
                    Category = caregory,
                    Displayed = request.Displayed,
                };
                _db.Products.Add(product);


                //UploadingImages
                List<ProductImages> productImages = new List<ProductImages>();

                foreach (var item in request.Images)
                {
                    var uploadedResult = UploadFile(item);
                    productImages.Add(new ProductImages
                    {
                        Product = product,
                        Src = uploadedResult.FileNameAddress
                    });
                }
                _db.ProductImages.AddRange(productImages);


                //Adding Product Features
                List<ProductFeatures> productFeatures = new List<ProductFeatures>();

                foreach (var item in request.Features)
                {
                    productFeatures.Add(new ProductFeatures
                    {
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                        Product = product
                    });
                }
                _db.ProductFeatures.AddRange(productFeatures);

                _db.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد"
                };

            }
            catch (Exception ex)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد "
                };
            }
            
        }



        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
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
