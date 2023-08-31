using Hyper_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Application.Services.Products.Queries
{
    public interface IGetProductDetailForAdmin
    {
        ResultDto<ProductDetailForAdminDto> Execute(long id);
    }
}
