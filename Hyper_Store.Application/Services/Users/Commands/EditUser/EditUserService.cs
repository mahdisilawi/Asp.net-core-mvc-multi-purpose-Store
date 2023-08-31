using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;

namespace Hyper_Store.Application.Services.Users.Commands.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IApplicationDbContext _db;

        public EditUserService(IApplicationDbContext db)
        {
            _db = db;
        }
        public ResultDto Execute(RequestEdituserDto request)
        {
            var user = _db.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FullName = request.Fullname;
            _db.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };

        }
    }
}
