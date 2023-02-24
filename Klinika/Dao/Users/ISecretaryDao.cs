// File:    ISecretaryDao.cs
// Created: Sunday, May 24, 2020 10:03:17 PM
// Purpose: Definition of Interface ISecretaryDao

using Model.Secretary;
using System;

namespace Dao.Users
{
   public interface ISecretaryDao : Dao.ICRUDDao<Secretary, string>
   {
   }
}