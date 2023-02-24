// File:    IQuestionDao.cs
// Created: Wednesday, May 27, 2020 2:28:25 PM
// Purpose: Definition of Class IQuestionDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Documents;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Patient;

namespace Dao.Documents.CSVImpl
{
    public class QuestionDao : IQuestionDao
    {
        private readonly ICSVStream<Question> _stream;
        private readonly ISequencer<long> _sequencer;

        public QuestionDao(ICSVStream<Question> stream, ISequencer<long> sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Question question) => DeleteById(question.Id);

        public void DeleteAll() => _stream.SaveAll(new List<Question>());

        public void DeleteById(long id)
        {
            List<Question> questions = _stream.ReadAll().ToList();
            Question toRemove = questions.SingleOrDefault(q => q.Id.CompareTo(id) == 0);
            if(toRemove != null)
            {
                questions.Remove(toRemove);
                _stream.SaveAll(questions);
            }
            else
            {
                Console.WriteLine("Pitanje nije pronadjeno");
            }
        }

        public bool ExistsById(long id) => FindById(id) == null ? false : true;

        public IEnumerable<Question> FindAll() => _stream.ReadAll().ToList();

        public Question FindById(long id) 
            => FindAll().SingleOrDefault(q => q.Id.CompareTo(id) == 0);

        public Question Save(Question newQuestion)
        {
            List<Question> questions = _stream.ReadAll().ToList();
            Question question = questions.SingleOrDefault(q => q.Id.CompareTo(newQuestion.Id) == 0);
            if (question != null)
            {
                questions[questions.FindIndex(q => q.Id.CompareTo(question.Id) == 0)] = newQuestion;
                _stream.SaveAll(questions);
            }
            else
            {
                newQuestion.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newQuestion);
            }
            return newQuestion;
        }

        public void SaveAll(IEnumerable<Question> newQuestions)
        {
            foreach(Question question in newQuestions)
            {
                Save(question);
            }
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Question> questions)
        {
            return questions.Count() == 0 ? 0 : questions.Max(question => question.Id);
        }
    }
}