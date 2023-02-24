// File:    IQuestionDao.cs
// Created: Thursday, May 14, 2020 7:49:57 PM
// Purpose: Definition of Interface IQuestionDao

using Model.Patient;

namespace Dao.Documents
{
   public interface IQuestionDao : Dao.ICRUDDao<Question, long>
   {
   }
}