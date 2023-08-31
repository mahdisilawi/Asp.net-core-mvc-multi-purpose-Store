using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Application.Interfaces.FacadPatterns;
using Hyper_Store.Application.Services.Products.Commands.AddNewCategory;
using Hyper_Store.Application.Services.Products.Commands.AddNewProduct;
using Hyper_Store.Application.Services.Products.Queries;
using Hyper_Store.Application.Services.Products.Queries.GetAllCategories;
using Hyper_Store.Application.Services.Products.Queries.GetCategories;
using Hyper_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Hyper_Store.Application.Services.Products.Queries.GetProductDetailForSite;
using Hyper_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Hyper_Store.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public ProductFacad(IApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }    
        
        
        private IGetCategoriesService  _getCategoriesService;
        public IGetCategoriesService  GetCategoriesService
        {
            get
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);
            }
        }

        private AddNewProductService _addNewProductService;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService = _addNewProductService ?? new AddNewProductService(_context, _environment);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }


        private  IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }

        private IGetProductDetailForAdmin _getProductDetailForAdmin;
        public IGetProductDetailForAdmin GetProductDetailForAdmin
        {
            get
            {
                return _getProductDetailForAdmin = _getProductDetailForAdmin ?? new GetProductDetailForAdmin(_context);
            }
        }

        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }
    }
}
