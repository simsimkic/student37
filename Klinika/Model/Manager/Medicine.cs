// File:    Medicine.cs
// Created: Thursday, April 9, 2020 11:13:15 PM
// Purpose: Definition of Class Medicine

using System;
using System.Collections.Generic;
using Model.Doctor;

namespace Model.Manager
{
   public class Medicine
   {
      public string Tag { get; set; }
      public string Name { get; set; }
      public int Amount { get; set; }
      public Valid Validation { get; set; }
      public List<Ingredient> ingredient { get; set; }
      public List<Diagnosis> Diagnosis { get; set; }
      
      /// <summary>
      /// Property for collection of Ingredient
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Ingredient> Ingredient
      {
         get
         {
            if (ingredient == null)
               ingredient = new System.Collections.Generic.List<Ingredient>();
            return ingredient;
         }
         set
         {
            RemoveAllIngredient();
            if (value != null)
            {
               foreach (Ingredient oIngredient in value)
                  AddIngredient(oIngredient);
            }
         }
      }
      
      /// <summary>
      /// Add a new Ingredient in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddIngredient(Ingredient newIngredient)
      {
         if (newIngredient == null)
            return;
         if (this.ingredient == null)
            this.ingredient = new System.Collections.Generic.List<Ingredient>();
         if (!this.ingredient.Contains(newIngredient))
            this.ingredient.Add(newIngredient);
      }
      
      /// <summary>
      /// Remove an existing Ingredient from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveIngredient(Ingredient oldIngredient)
      {
         if (oldIngredient == null)
            return;
         if (this.ingredient != null)
            if (this.ingredient.Contains(oldIngredient))
               this.ingredient.Remove(oldIngredient);
      }
      
      /// <summary>
      /// Remove all instances of Ingredient from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllIngredient()
      {
         if (ingredient != null)
            ingredient.Clear();
      }
      public Doctor.Doctor doctor;
        private string v1;
        private string v2;
        private int v3;
        private Valid valid;

        public Medicine() {
        }

        public Medicine(string tag, string name, int amount, Valid validation, List<Ingredient> ingredients)
        {
            Tag = tag;
            Name = name;
            Amount = amount;
            Validation = validation;
            Ingredient = ingredients;
        }

        public Medicine(string v1, string v2, int v3, Valid valid)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.valid = valid;
        }

        public Medicine(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}