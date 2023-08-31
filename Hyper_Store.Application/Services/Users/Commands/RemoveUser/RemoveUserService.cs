using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;
using System;
using System.Linq;

namespace Hyper_Store.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IApplicationDbContext _context;

        public RemoveUserService(IApplicationDbContext context)
        {
            _context = context;
        }


        public ResultDto Execute(long UserId)
        {
 
            var user = _context.Users.Find(UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}
