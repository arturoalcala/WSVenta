﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.DBModels.Response;

namespace WSVenta.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
