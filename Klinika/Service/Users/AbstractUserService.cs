// File:    AbstractUserService.cs
// Created: Tuesday, May 26, 2020 4:39:41 PM
// Purpose: Definition of Class AbstractUserService

using Dao.Users;
using Dao.Users.CSVImpl;
using Klinika.Dao.Users;
using Klinika.Dao.Users.CSVImpl;
using Klinika.Dto;
using Klinika.Service.Users;
using Model.User;
using System;

namespace Service.Users
{
    public abstract class AbstractUserService<T>
    {
        protected AbstractUserService(UserValidationService userValidationService, AddressService addressService, IUserDao userDao, IAccountDao accountDao)
        {
            _validationService = userValidationService;
            _addressService = addressService;
            _userDao = userDao;
            _accountDao = accountDao;
        }
        private readonly UserValidationService _validationService;
        private readonly AddressService _addressService;
        private readonly IUserDao _userDao;
        private readonly IAccountDao _accountDao;
      
        protected abstract T RegisterRoleData(Dto.RegisterUserDTO user);
      
        protected abstract T GetRoleData(User user);
      
        protected abstract void DeleteFromRoleTable(string jmbg);
      
        public T Register(Dto.RegisterUserDTO dto)
        {
            User user = new User(dto.Jmbg, dto.Name, dto.LastName, dto.Username, dto.Email, 
                dto.Phone, dto.BirthDate, dto.Roles, dto.Address);

            //proverava da li je korisnik vec registrovan
            if (_validationService.IsRegisteredUser(user))
            {
                //default(T) ce biti null
                return default(T);
            }
            //cuva adresu korisnika
            user.Address = _addressService.AddAddress(user.Address);
            //upisuje u tabelu user-a
            _userDao.Save(user);

            //Cuva lozinku u zasebnom fajlu
            _accountDao.Save(new AccountDTO(dto.Username, dto.Password));

            //upisuje u odgovarajucu tabelu uloge
            return RegisterRoleData(dto);
        }
        public void Save(Dto.RegisterUserDTO dto)
        {
            User user = new User(dto.Jmbg, dto.Name, dto.LastName, dto.Username, dto.Email,
                dto.Phone, dto.BirthDate, dto.Roles, dto.Address);

           
            //cuva adresu korisnika
            user.Address = _addressService.AddAddress(user.Address);
            //upisuje u tabelu user-a
            _userDao.Save(user);

            //Cuva lozinku u zasebnom fajlu
            _accountDao.Save(new AccountDTO(dto.Username, dto.Password));

            
            
        }

        public T Login(string username, string password)
        {
            if (!_validationService.IsUserNameValid(username))
            {
                return default(T);
            }
            else if (!_validationService.IsPasswordValid(username, password))
            {
                return default(T);
            }
            return GetRoleData(_userDao.FindByUsername(username));
        }
      
        public void DeleteUser(User user)
        {
            _userDao.Delete(user);
            _accountDao.DeleteById(user.Username);
            DeleteFromRoleTable(user.Jmbg);
        }

        public T GetUserById(string jmbg)
            => GetRoleData(_userDao.FindById(jmbg));
   
   }
}