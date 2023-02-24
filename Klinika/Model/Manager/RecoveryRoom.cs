// File:    RecoveryRoom.cs
// Created: Saturday, April 18, 2020 5:28:59 PM
// Purpose: Definition of Class RecoveryRoom

using Model.Secretary;
using System;

namespace Model.Manager
{
   public class RecoveryRoom : Room
   {
      public int TotalSpots { get; set; }
      public int FreeSpots { get; set; }

      public RecoveryRoom() { }
      public RecoveryRoom(string id) : base(id) { }
      public RecoveryRoom(Room r, int total, int free) : base(r)
        {
            TotalSpots = total;
            FreeSpots = free;
        }
      
      public System.Collections.Generic.List<MedicalOperation> medicalOperation;
      
      /// <summary>
      /// Property for collection of Model.Secretary.MedicalOperation
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<MedicalOperation> MedicalOperation
      {
         get
         {
            if (medicalOperation == null)
               medicalOperation = new System.Collections.Generic.List<MedicalOperation>();
            return medicalOperation;
         }
         set
         {
            RemoveAllMedicalOperation();
            if (value != null)
            {
               foreach (MedicalOperation oMedicalOperation in value)
                  AddMedicalOperation(oMedicalOperation);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.Secretary.MedicalOperation in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddMedicalOperation(MedicalOperation newMedicalOperation)
      {
         if (newMedicalOperation == null)
            return;
         if (this.medicalOperation == null)
            this.medicalOperation = new System.Collections.Generic.List<MedicalOperation>();
         if (!this.medicalOperation.Contains(newMedicalOperation))
         {
            this.medicalOperation.Add(newMedicalOperation);
            newMedicalOperation.RecoveryRoom = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Model.Secretary.MedicalOperation from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveMedicalOperation(MedicalOperation oldMedicalOperation)
      {
         if (oldMedicalOperation == null)
            return;
         if (this.medicalOperation != null)
            if (this.medicalOperation.Contains(oldMedicalOperation))
            {
               this.medicalOperation.Remove(oldMedicalOperation);
               oldMedicalOperation.RecoveryRoom = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Model.Secretary.MedicalOperation from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllMedicalOperation()
      {
         if (medicalOperation != null)
         {
            System.Collections.ArrayList tmpMedicalOperation = new System.Collections.ArrayList();
            foreach (MedicalOperation oldMedicalOperation in medicalOperation)
               tmpMedicalOperation.Add(oldMedicalOperation);
            medicalOperation.Clear();
            foreach (MedicalOperation oldMedicalOperation in tmpMedicalOperation)
               oldMedicalOperation.RecoveryRoom = null;
            tmpMedicalOperation.Clear();
         }
      }
   
   }
}