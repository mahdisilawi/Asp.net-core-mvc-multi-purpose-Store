using Hyper_Store.Application.Services.Products.Commands.AddNewCategory;
using Hyper_Store.Application.Services.Products.Commands.AddNewCategory;
using Hyper_Store.Application.Services.Products.Commands.AddNewProduct;
using Hyper_Store.Application.Services.Products.Queries;
using Hyper_Store.Application.Services.Products.Queries.GetAllCategories;
using Hyper_Store.Application.Services.Products.Queries.GetCategories;
using Hyper_Store.Application.Services.Products.Queries.GetProductDetailForSite;
using Hyper_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Hyper_Store.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService  GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdmin GetProductDetailForAdmin { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
