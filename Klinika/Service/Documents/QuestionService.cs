// File:    QuestionService.cs
// Created: Wednesday, May 13, 2020 6:44:15 PM
// Purpose: Definition of Class QuestionService

using Dao.Documents;
using Dao.Documents.CSVImpl;
using Dao.Users;
using Dao.Users.CSVImpl;
using Dto;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Documents
{
    public class QuestionService
    {
        private readonly IQuestionDao questionDao;
        private readonly IPatientDao patientDao;

        public Question AddQuestion(Patient patient, Question question)
        {
            Question newQuestion = questionDao.Save(question);
            Patient p = patientDao.FindById(patient.Jmbg);
            p.Questions.Add(newQuestion);
            patientDao.Save(p);
            return newQuestion;
        }

        public Question AnswerQuestion(Question question)
            => questionDao.Save(question);

        public List<Question> GetAllQuestions()
            => (List<Question>)questionDao.FindAll();

        public List<Question> GetPatientQuestions(Patient patient)
        {
            List<Question> questions = new List<Question>();
            patient = patientDao.FindById(patient.Jmbg);
            patient.Questions.ForEach(q => questions.Add(questionDao.FindById(q.Id)));
            return questions;
        }
   
   }
}