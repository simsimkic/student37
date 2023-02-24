// File:    RefferalLetterDao.cs
// Created: Wednesday, May 27, 2020 2:28:25 PM
// Purpose: Definition of Class RefferalLetterDao

using System;
using System.Collections.Generic;
using Dto;
using Model.Doctor;
using Klinika.Database.Sequencer;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Csv.Converter.Documents;
using System.Linq;

namespace Dao.Documents.CSVImpl
{
    public class ReferralLetterDao : IReferralLetterDao
    {
        private ICSVStream<ReferralLetter> _stream;
        private ISequencer<long> _sequencer;

        public ReferralLetterDao(string path, string delimiter)
        {
            _stream = new CSVStream<ReferralLetter>(path, new ReferralLetterCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public ReferralLetterDao(ICSVStream<ReferralLetter> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public ReferralLetterDao(ICSVStream<ReferralLetter> stream)
        {
            _stream = stream;
            _sequencer = new LongSequencer();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        public int Count() => _stream.ReadAll().ToList().Count;

        private long GetMaxId(IEnumerable<ReferralLetter> referralLetter)
        {
            return referralLetter.Count() == 0 ? 0 : referralLetter.Max(referral => referral.Id);
        }

        public void Delete(ReferralLetter referralLetter) => DeleteById(referralLetter.Id);

        public void DeleteAll() => _stream.SaveAll(new List<ReferralLetter>());

        public void DeleteById(long id)
        {
            List<ReferralLetter> referralLetters = _stream.ReadAll().ToList();
            ReferralLetter toRemove = referralLetters.SingleOrDefault(q => q.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                referralLetters.Remove(toRemove);
                _stream.SaveAll(referralLetters);
            }
            else
            {
                Console.WriteLine("Uput nije pronadjen");
            }
        }

        public bool ExistsById(long id) => FindById(id) == null ? false : true;


        public IEnumerable<ReferralLetter> FindAll() => _stream.ReadAll().ToList();


        public ReferralLetter FindById(long id) => FindAll().SingleOrDefault(q => q.Id.CompareTo(id) == 0);
        

        public ReferralLetter Save(ReferralLetter newReferralLetter)
        {
            List<ReferralLetter> referralLetters = _stream.ReadAll().ToList();
            if (referralLetters == null) {
                referralLetters = new List<ReferralLetter>();
            }
            ReferralLetter referralLetter = referralLetters.SingleOrDefault(q => q.Id.CompareTo(newReferralLetter.Id) == 0);

            if (referralLetter != null)
            {
                referralLetters[referralLetters.FindIndex(q => q.Id.CompareTo(referralLetter.Id) == 0)] = newReferralLetter;
                _stream.SaveAll(referralLetters);
            }
            else
            {
                newReferralLetter.Id = referralLetters.Count()+1;
                _stream.AppendToFile(newReferralLetter);
            }
            return newReferralLetter;
        }

        public void SaveAll(IEnumerable<ReferralLetter> newReferralLetters)
        {
            foreach (ReferralLetter referral in newReferralLetters)
            {
                Save(referral);
            }
        }

        
    }
}