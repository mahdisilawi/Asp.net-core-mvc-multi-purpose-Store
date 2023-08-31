using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common;

namespace Hyper_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUserService : IGetUserService
    {
        private readonly IApplicationDbContext _db;
        public GetUserService(IApplicationDbContext db)
        {
            _db = db;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _db.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            int rowsCount = 0;
            var usersList =  users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                FullName = p.FullName,
                Email = p.Email,
                Id = p.Id,
                IsActive = p.IsActive
            }).ToList();

            return new ResultGetUserDto
            {
                Users = usersList,
                Rows = rowsCount
            };
        }
    }
}
