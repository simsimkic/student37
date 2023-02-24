// File:    ICRUDDao.cs
// Created: Thursday, May 14, 2020 4:43:27 PM
// Purpose: Definition of Interface ICRUDDao

using System;
using System.Collections.Generic;

namespace Dao
{
   public interface ICRUDDao<T,ID>
   {
      int Count();
      
      void Delete(T entity);
      
      void DeleteAll();
      
      void DeleteById(ID id);
      
      bool ExistsById(ID id);
      
      T FindById(ID id);
      
      IEnumerable<T> FindAll();
      
      T Save(T entity);
      
      void SaveAll(IEnumerable<T> entities);
   
   }
}