// File:    MedicalExaminationDao.cs
// Created: Wednesday, May 27, 2020 2:42:43 PM
// Purpose: Definition of Class MedicalExaminationDao

using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Klinika.Database.Csv.Converter.MedicalServices;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;

using Model.Doctor;

namespace Dao.MedicalServices.CSVImpl
{
    public class MedicalExaminationDao : IMedicalExaminationDao
    {

        private readonly ICSVStream<MedicalExamination> _stream;
        private ISequencer<long> _sequencer;

        public MedicalExaminationDao(string path, string delimiter)
        {
            _stream = new CSVStream<MedicalExamination>(path, new MedicalExaminationCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public MedicalExaminationDao(ICSVStream<MedicalExamination> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public MedicalExaminationDao(ICSVStream<MedicalExamination> stream)
        {
            _stream = stream;
            _sequencer = new LongSequencer();
            InitializeId();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<MedicalExamination> medicalExamination)
        {
            return medicalExamination.Count() == 0 ? 0 : medicalExamination.Max(diag => diag.Id);
        }

        public int Count() => _stream.ReadAll().ToList().Count;


        public void Delete(MedicalExamination medicalExamination) => DeleteById(medicalExamination.Id);


        public void DeleteAll() => _stream.SaveAll(new List<MedicalExamination>());


        public void DeleteById(long id)
        {
            List<MedicalExamination> medicalExaminations = _stream.ReadAll().ToList();
            MedicalExamination toRemove = medicalExaminations.SingleOrDefault(q => q.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                medicalExaminations.Remove(toRemove);
                _stream.SaveAll(medicalExaminations);
            }
            else
            {
                Console.WriteLine("Pregled nije pronadjen");
            }
        }

        public bool ExistsById(long id) => FindById(id) == null ? false : true;


        public IEnumerable<MedicalExamination> FindAll() => _stream.ReadAll().ToList();


        public MedicalExamination FindById(long id) => FindAll().SingleOrDefault(q => q.Id.CompareTo(id) == 0);


        public MedicalExamination Save(MedicalExamination newExamination)
        {
            List<MedicalExamination> medicalExamination = _stream.ReadAll().ToList();
            MedicalExamination exam = medicalExamination.SingleOrDefault(q => q.Id.CompareTo(newExamination.Id) == 0);
            if (exam != null)
            {
                medicalExamination[medicalExamination.FindIndex(q => q.Id.CompareTo(exam.Id) == 0)] = newExamination;
                _stream.SaveAll(medicalExamination);
            }
            else
            {
                newExamination.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newExamination);
            }
            return newExamination;
        }

        public void SaveAll(IEnumerable<MedicalExamination> newExams)
        {
            foreach (MedicalExamination exam in newExams)
            {
                Save(exam);
            }
        }
        
    }
}