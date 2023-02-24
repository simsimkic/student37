// File:    PatientAccounts.cs
// Created: Sunday, April 12, 2020 9:06:52 PM
// Purpose: Definition of Class PatientAccounts

using System;

namespace Model.Secretary
{
   public class PatientAccounts
   {
      public System.Collections.ArrayList patients;
      
      /// <summary>
      /// Property for collection of Model.Patient.Patient
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList Patients
      {
         get
         {
            if (patients == null)
               patients = new System.Collections.ArrayList();
            return patients;
         }
         set
         {
            RemoveAllPatients();
            if (value != null)
            {
               foreach (Model.Patient.Patient oPatient in value)
                  AddPatients(oPatient);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.Patient.Patient in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPatients(Model.Patient.Patient newPatient)
      {
         if (newPatient == null)
            return;
         if (this.patients == null)
            this.patients = new System.Collections.ArrayList();
         if (!this.patients.Contains(newPatient))
            this.patients.Add(newPatient);
      }
      
      /// <summary>
      /// Remove an existing Model.Patient.Patient from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePatients(Model.Patient.Patient oldPatient)
      {
         if (oldPatient == null)
            return;
         if (this.patients != null)
            if (this.patients.Contains(oldPatient))
               this.patients.Remove(oldPatient);
      }
      
      /// <summary>
      /// Remove all instances of Model.Patient.Patient from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPatients()
      {
         if (patients != null)
            patients.Clear();
      }
   
   }
}