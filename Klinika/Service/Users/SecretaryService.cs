// File:    SecretaryService.cs
// Created: Sunday, May 24, 2020 11:50:32 PM
// Purpose: Definition of Class SecretaryService

using System;
using System.Collections.Generic;
using Dao.Employees;
using Dao.Users;
using Dto;
using Klinika.Dao.Users;
using Klinika.Service.Users;
using Model.Manager;
using Model.Secretary;
using Model.User;

namespace Service.Users
{
   public class SecretaryService : AbstractUserService<Secretary>
   {
        public IScheduleDao _scheduleDao;
        public ISecretaryDao _secretaryDao;
        public SecretaryService(ISecretaryDao secretaryDao, IScheduleDao scheduleDao, UserValidationService userValidationService,
            AddressService addressService, IUserDao userDao, IAccountDao accountDao)
            : base(userValidationService, addressService, userDao, accountDao)
        {
            _secretaryDao = secretaryDao;
            _scheduleDao = scheduleDao;
        }
      public WorkTime ViewWorkingTime(WorkTime workTime)
      {
         throw new NotImplementedException();
      }
      
      public void SetWorkingTime(WorkTime workTime)
      {
         throw new NotImplementedException();
      }
      
      public Schedule GetSchedule()
      {
         throw new NotImplementedException();
      }
      
      public void SetSchedule()
      {
         throw new NotImplementedException();
      }
        public Secretary GetSecretary(string jmbg)
            => _secretaryDao.FindById(jmbg);

        public List<Secretary> GetAllSecretaries()
            => (List<Secretary>)_secretaryDao.FindAll();

        protected override Secretary RegisterRoleData(RegisterUserDTO user)
        {
            throw new NotImplementedException();
        }

        protected override Secretary GetRoleData(User user)
        {
            throw new NotImplementedException();
        }

        protected override void DeleteFromRoleTable(string jmbg)
        {
            throw new NotImplementedException();
        }


   
   }
}