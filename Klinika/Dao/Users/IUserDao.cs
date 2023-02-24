// File:    IUserDao.cs
// Created: Sunday, May 24, 2020 9:52:34 PM
// Purpose: Definition of Interface IUserDao

using Model.User;
using System;

namespace Dao.Users
{
   public interface IUserDao : ICRUDDao<User, string>
   {
        User FindByUsername(string username);
   }
}