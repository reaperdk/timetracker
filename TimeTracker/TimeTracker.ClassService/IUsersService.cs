﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public interface IUsersService
    {
        IEnumerable<UserModel> GetAllUsers();
        UserModel GetById(int id);
        void Add(UserModel user);
        void Update(UserModel user);
        void Remove(int id);
    }
}
