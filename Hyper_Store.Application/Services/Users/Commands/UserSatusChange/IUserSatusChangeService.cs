﻿using Hyper_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Application.Services.Users.Commands.UserSatusChange
{
    public interface IUserSatusChangeService
    {
        ResultDto Execute(long UserId);
    }
}
