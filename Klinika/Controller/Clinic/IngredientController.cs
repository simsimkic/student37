// File:    IngredientController.cs
// Created: Wednesday, May 27, 2020 5:56:54 PM
// Purpose: Definition of Class IngredientController

using Model.Manager;
using Service.Clinic;
using System;
using System.Collections.Generic;

namespace Controller.Clinic
{
   public class IngredientController
   {
        private readonly IngredientService _ingredientService;

        public IngredientController(IngredientService service)
        {
            _ingredientService = service;
        }
        public Ingredient AddIngredient(Ingredient newIngredient)
              => _ingredientService.AddIngredient(newIngredient);

        public Ingredient GetIngredient(long id)
            => _ingredientService.GetIngredient(id);

        public Ingredient GetIngredient(string ingredientName)
              => _ingredientService.GetIngredient(ingredientName);

        public List<Ingredient> GetAllIngredients()
              => _ingredientService.GetAllIngredients();  
   }
}