// File:    ManagerService.cs
// Created: Thursday, May 28, 2020 10:21:41 PM
// Purpose: Definition of Class ManagerService

using System;
using Dao.Users;
using Dto;
using Klinika.Dao.Users;
using Klinika.Service.Users;
using Model.Manager;
using Model.User;

namespace Service.Users
{
   public class ManagerService : AbstractUserService<Manager>
   {
      private readonly IManagerDao _managerDao;
        public ManagerService(IManagerDao managerDao, UserValidationService userValidationService, 
            AddressService addressService, IUserDao userDao, IAccountDao accountDao)
            : base(userValidationService, addressService, userDao, accountDao)
        {
            _managerDao = managerDao;
        }

        protected override void DeleteFromRoleTable(string jmbg)
        {
            throw new NotImplementedException();
        }

        protected override Manager GetRoleData(User user)
        {
            throw new NotImplementedException();
        }

        protected override Manager RegisterRoleData(RegisterUserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}