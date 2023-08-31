using Hyper_Store.Application.Services.Users.Commands.EditUser;
using Hyper_Store.Application.Services.Users.Commands.RegisterUser;
using Hyper_Store.Application.Services.Users.Commands.RemoveUser;
using Hyper_Store.Application.Services.Users.Commands.UserSatusChange;
using Hyper_Store.Application.Services.Users.Queries.GetRoles;
using Hyper_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        //services injection
        private readonly IGetUserService _getUserService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;

        public UsersController(
            IGetUserService getUserService,
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IUserSatusChangeService userSatusChangeService,
            IEditUserService editUserService
            )
        {
            _getUserService = getUserService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_getUserService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                Roles = new List<RolesRegisterUserDto>()
                   {
                        new RolesRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePassword = RePassword, 
            });
            return Json(result);
        }


        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }


        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userSatusChangeService.Execute(UserId));
        }


        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
            }));
        }

    }
}
