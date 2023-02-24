// File:    IIngredientDao.cs
// Created: Thursday, May 21, 2020 1:25:39 PM
// Purpose: Definition of Interface IIngredientDao

using Model.Manager;

namespace Dao.Clinic
{
   public interface IIngredientDao : ICRUDDao<Ingredient, long>
   {
        Ingredient FindByName(string name);
   }
}