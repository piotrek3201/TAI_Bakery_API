﻿using WebApp.Model;

namespace WebApp.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(long id);
    }
}
