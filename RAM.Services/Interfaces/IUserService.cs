﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Services.Messaging.UserService;
using RAM.Core.Domain.User;

namespace RAM.Services.Interfaces
{
    public interface IUserService
    {
        GetUserResponse GetUser(GetUserRequest request);
        GetValidUserResponse AuthenticateUser(string email, string password);
        User FindByID(int id);
    }
}
