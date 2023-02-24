// File:    UserDao.cs
// Created: Wednesday, May 27, 2020 2:44:54 PM
// Purpose: Definition of Class UserDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Users;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.User;

namespace Dao.Users.CSVImpl
{
    public class UserDao : IUserDao
    {
        private readonly ICSVStream<User> _stream;

        public UserDao(string path, string delimiter)
        {
            _stream = new CSVStream<User>(path, new UserCSVConverter(delimiter));
        }

        public UserDao(ICSVStream<User> stream)
        {
            _stream = stream;
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(User user) => DeleteById(user.Jmbg);

        public void DeleteAll() => _stream.SaveAll(new List<User>());

        public void DeleteById(string jmbg)
        {
            List<User> users = _stream.ReadAll().ToList();
            User toRemove = users.SingleOrDefault(u => u.Jmbg.CompareTo(jmbg) == 0);
            if (toRemove != null)
            {
                users.Remove(toRemove);
                _stream.SaveAll(users);
            }
            else
            {
                Console.WriteLine("Korisnik nije pronadjen");
            }
        }

        public bool ExistsById(string jmbg)
        {
            List<User> users = _stream.ReadAll().ToList();
            User user = users.SingleOrDefault(u => u.Jmbg.CompareTo(jmbg) == 0);
            return user == null ? false : true;
        }

        public IEnumerable<User> FindAll() => _stream.ReadAll().ToList();

        public User FindById(string jmbg)
        {
            List<User> users = _stream.ReadAll().ToList();
            return users.SingleOrDefault(u => u.Jmbg.CompareTo(jmbg) == 0);
        }

        public User FindByUsername(string username)
        {
            List<User> users = _stream.ReadAll().ToList();
            return users.SingleOrDefault(u => u.Username.CompareTo(username) == 0);
        }

        public User Save(User user)
        {
            List<User> users = _stream.ReadAll().ToList();
            User oldUser = users.SingleOrDefault(u => u.Jmbg.CompareTo(user.Jmbg) == 0);
            if(oldUser != null)
            {
                Delete(oldUser);
            }
            _stream.AppendToFile(user);
            return user;
        }

        public void SaveAll(IEnumerable<User> newUsers)
        {
            List<User> users = _stream.ReadAll().ToList();
            foreach (User user in newUsers)
            {
                User oldUser = users.SingleOrDefault(u => u.Jmbg.CompareTo(user.Jmbg) == 0);
                if (oldUser != null)
                {
                    Delete(oldUser);
                }
                _stream.AppendToFile(user);
            }
        }

    }
}