// File:    QuestionController.cs
// Created: Wednesday, May 13, 2020 6:44:15 PM
// Purpose: Definition of Class QuestionController

using Dto;
using Model.Patient;
using Service.Documents;
using System;
using System.Collections.Generic;

namespace Controller.Documents
{
    public class QuestionController
    {
        public QuestionService questionService = new QuestionService();
        public Question AddQuestion(Patient patient, Question question)
            => questionService.AddQuestion(patient, question);

        public Question AnswerQuestion(Question question)
            => questionService.AnswerQuestion(question);

        public List<Question> GetAllQuestions()
            => questionService.GetAllQuestions();

        public List<Question> GetPatientQuestions(Patient patient)
            => questionService.GetPatientQuestions(patient);

    }
}