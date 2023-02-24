// File:    Diagnosis.cs
// Created: Friday, April 17, 2020 2:19:04 PM
// Purpose: Definition of Class Diagnosis

using Klinika.Database;
using Model.Manager;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class Diagnosis : IIdentifiable<long>
   {
      public long Id { get; set; }
      public string Name { get; set; }
      public List<Treatment> medicalTreatment { get; set; }          
      public List<MedicalPrescription> medicalPrescription { get; set; }       

        public Diagnosis(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Property for collection of MedicalTreatment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Treatment> MedicalTreatment
      {
         get
         {
            if (medicalTreatment == null)
               medicalTreatment = new System.Collections.Generic.List<Treatment>();
            return medicalTreatment;
         }
         set
         {
            RemoveAllMedicalTreatment();
            if (value != null)
            {
               foreach (Treatment oMedicalTreatment in value)
                  AddMedicalTreatment(oMedicalTreatment);
            }
         }
      }
      
      /// <summary>
      /// Add a new MedicalTreatment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddMedicalTreatment(Treatment newMedicalTreatment)
      {
         if (newMedicalTreatment == null)
            return;
         if (this.medicalTreatment == null)
            this.medicalTreatment = new System.Collections.Generic.List<Treatment>();
         if (!this.medicalTreatment.Contains(newMedicalTreatment))
            this.medicalTreatment.Add(newMedicalTreatment);
      }
      
      /// <summary>
      /// Remove an existing MedicalTreatment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveMedicalTreatment(Treatment oldMedicalTreatment)
      {
         if (oldMedicalTreatment == null)
            return;
         if (this.medicalTreatment != null)
            if (this.medicalTreatment.Contains(oldMedicalTreatment))
               this.medicalTreatment.Remove(oldMedicalTreatment);
      }
      
      /// <summary>
      /// Remove all instances of MedicalTreatment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllMedicalTreatment()
      {
         if (medicalTreatment != null)
            medicalTreatment.Clear();
      }
     
      
      /// <summary>
      /// Property for collection of MedicalPrescription
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<MedicalPrescription> MedicalPrescription
      {
         get
         {
            if (medicalPrescription == null)
               medicalPrescription = new System.Collections.Generic.List<MedicalPrescription>();
            return medicalPrescription;
         }
         set
         {
            RemoveAllMedicalPrescription();
            if (value != null)
            {
               foreach (MedicalPrescription oMedicalPrescription in value)
                  AddMedicalPrescription(oMedicalPrescription);
            }
         }
      }
      
      /// <summary>
      /// Add a new MedicalPrescription in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddMedicalPrescription(MedicalPrescription newMedicalPrescription)
      {
         if (newMedicalPrescription == null)
            return;
         if (this.medicalPrescription == null)
            this.medicalPrescription = new System.Collections.Generic.List<MedicalPrescription>();
         if (!this.medicalPrescription.Contains(newMedicalPrescription))
            this.medicalPrescription.Add(newMedicalPrescription);
      }
      
      /// <summary>
      /// Remove an existing MedicalPrescription from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveMedicalPrescription(MedicalPrescription oldMedicalPrescription)
      {
         if (oldMedicalPrescription == null)
            return;
         if (this.medicalPrescription != null)
            if (this.medicalPrescription.Contains(oldMedicalPrescription))
               this.medicalPrescription.Remove(oldMedicalPrescription);
      }
      
      /// <summary>
      /// Remove all instances of MedicalPrescription from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllMedicalPrescription()
      {
         if (medicalPrescription != null)
            medicalPrescription.Clear();
      }
      public System.Collections.Generic.List<Medicine> medicine;
      
      /// <summary>
      /// Property for collection of Model.Manager.Medicine
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Medicine> Medicine
      {
         get
         {
            if (medicine == null)
               medicine = new System.Collections.Generic.List<Medicine>();
            return medicine;
         }
         set
         {
            RemoveAllMedicine();
            if (value != null)
            {
               foreach (Model.Manager.Medicine oMedicine in value)
                  AddMedicine(oMedicine);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.Manager.Medicine in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddMedicine(Model.Manager.Medicine newMedicine)
      {
         if (newMedicine == null)
            return;
         if (this.medicine == null)
            this.medicine = new System.Collections.Generic.List<Medicine>();
         if (!this.medicine.Contains(newMedicine))
            this.medicine.Add(newMedicine);
      }
      
      /// <summary>
      /// Remove an existing Model.Manager.Medicine from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveMedicine(Model.Manager.Medicine oldMedicine)
      {
         if (oldMedicine == null)
            return;
         if (this.medicine != null)
            if (this.medicine.Contains(oldMedicine))
               this.medicine.Remove(oldMedicine);
      }
      
      /// <summary>
      /// Remove all instances of Model.Manager.Medicine from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllMedicine()
      {
         if (medicine != null)
            medicine.Clear();
      }


      

        public Diagnosis(long id)
        {
            Id = id;
        }

        public Diagnosis(long id, string name)
        {
        }

        public Diagnosis()
        {
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}