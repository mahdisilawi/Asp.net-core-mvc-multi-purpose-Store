using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Hyper_Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IApplicationDbContext _db;

        public GetRolesService(IApplicationDbContext db)
        {
            _db = db;
        }
        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _db.Roles.ToList().Select(p => new RolesDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
