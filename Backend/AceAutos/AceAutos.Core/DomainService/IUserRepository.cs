﻿using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        void Add(User newUser);
        User Edit(int id, User updateUser);
        void Remove(long id);
        User GetUserByUsername(string username);
        List<User> GetAllUsers();
        User DeleteUser(int id);
        User GetUserById(int id);
    }
}
