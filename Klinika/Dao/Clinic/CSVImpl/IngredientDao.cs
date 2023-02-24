// File:    IngredientDao.cs
// Created: Wednesday, May 27, 2020 2:19:12 PM
// Purpose: Definition of Class IngredientDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Manager;

namespace Dao.Clinic.CSVImpl
{
    public class IngredientDao : IIngredientDao
    {
        ICSVStream<Ingredient> _stream;
        ISequencer<long> _sequencer;

        public IngredientDao(string path, string delimiter)
        {
            _stream = new CSVStream<Ingredient>(path, new IngredientCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }
        public IngredientDao(ICSVStream<Ingredient> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public IngredientDao(ICSVStream<Ingredient> stream)
        {
            _stream = stream;
            _sequencer = new LongSequencer();
        }

        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Ingredient ingredient) => DeleteById(ingredient.Id);

        public void DeleteAll() => SaveAll(new List<Ingredient>());

        public void DeleteById(long id)
        {
            List<Ingredient> ingredients = _stream.ReadAll().ToList();
            Ingredient toDelete = ingredients.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toDelete != null)
            {
                ingredients.Remove(toDelete);
                _stream.SaveAll(ingredients);
            }
            else
                Console.WriteLine("Ingredient not found!");
        }

        public bool ExistsById(long id) => FindById(id) != null ? true : false;

        public IEnumerable<Ingredient> FindAll() => _stream.ReadAll().ToList();

        public Ingredient FindById(long id)
            => FindAll().SingleOrDefault(r => r.Id.CompareTo(id) == 0);

        public Ingredient FindByName(string name)
            => FindAll().SingleOrDefault(r => r.Name.CompareTo(name) == 0);

        public Ingredient Save(Ingredient newIngredient)
        {
            List<Ingredient> ingredients = _stream.ReadAll().ToList();
            Ingredient ing = ingredients.SingleOrDefault(r => r.Id.CompareTo(newIngredient.Id) == 0);
            if (ing != null)
            {
                ingredients[ingredients.FindIndex(r => r.Id.CompareTo(newIngredient.Id) == 0)] = newIngredient;
                _stream.SaveAll(ingredients);
            }
            else
            {
                newIngredient.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newIngredient);
            }    
            return newIngredient;
        }

        public void SaveAll(IEnumerable<Ingredient> ingredients)
        {
            foreach (Ingredient i in ingredients)
                Save(i);
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Ingredient> ings)
        {
            return ings.Count() == 0 ? 0 : ings.Max(i => i.Id);
        }
    }
}