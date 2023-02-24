// File:    UserValidationService.cs
// Created: Thursday, May 28, 2020 9:57:05 PM
// Purpose: Definition of Class UserValidationService

using Dao.Users;
using Klinika.Dao.Users;
using Model.User;
using System.Collections.Generic;

namespace Service.Users
{
    public class UserValidationService
    {
        private readonly IAccountDao _accountDao;
        private readonly IUserDao _userDao;
        public UserValidationService(IAccountDao accountDao, IUserDao userDao)
        {
            _accountDao = accountDao;
            _userDao = userDao;
        }
        public bool IsRegisteredUser(User user)
        {
            IEnumerable<User> users = _userDao.FindAll();
            foreach (User u in users)
            {
                if (u.Jmbg.Equals(user.Jmbg)
                    || u.Username.Equals(user.Username)
                    || u.Email.Equals(user.Email))
                    return true;
            }
            return false;
        }

        public bool IsPasswordValid(string username, string password)
            => _accountDao.FindById(username).Password.Equals(password);

        public bool IsUserNameValid(string username)
            => _userDao.FindByUsername(username) == null ? false : true;

    }
}