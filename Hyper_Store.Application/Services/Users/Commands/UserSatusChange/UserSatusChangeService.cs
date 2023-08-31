using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;

namespace Hyper_Store.Application.Services.Users.Commands.UserSatusChange
{
    public class UserSatusChangeService : IUserSatusChangeService
    {
        private readonly IApplicationDbContext _db;


        public UserSatusChangeService(IApplicationDbContext db)
        {
            _db = db;
        }

        public ResultDto Execute(long UserId)
        {
            var user = _db.Users.Find(UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.IsActive = !user.IsActive;
            _db.SaveChanges();
            string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userstate} شد!",
            };
        }
    }
}
