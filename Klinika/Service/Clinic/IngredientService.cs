// File:    IngredientService.cs
// Created: Wednesday, May 27, 2020 5:56:54 PM
// Purpose: Definition of Class IngredientService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Model.Manager;
using System;
using System.Collections.Generic;

namespace Service.Clinic
{
   public class IngredientService
   {
        private readonly IIngredientDao _ingredientDao;

        public IngredientService(IIngredientDao dao)
        {
            _ingredientDao = dao;
        }

        public Ingredient AddIngredient(Ingredient newIngredient)
        {
            Ingredient i = _ingredientDao.FindByName(newIngredient.Name);
            if (i == null)
                i = _ingredientDao.Save(newIngredient);
            return i;
        }

        public Ingredient GetIngredient(long id)
            => _ingredientDao.FindById(id);

        public Ingredient GetIngredient(string ingredientName)
              => _ingredientDao.FindByName(ingredientName);

        public List<Ingredient> GetAllIngredients()
              => (List<Ingredient>) _ingredientDao.FindAll();
   }
}