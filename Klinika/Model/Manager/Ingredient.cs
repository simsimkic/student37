// File:    Ingredient.cs
// Created: Thursday, April 16, 2020 3:45:48 PM
// Purpose: Definition of Class Ingredient

using Klinika.Database;
using System;

namespace Model.Manager
{
   public class Ingredient : IIdentifiable<long>
   {
        public Ingredient(long id)
        {
            Id = id;
        }

        public Ingredient(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}