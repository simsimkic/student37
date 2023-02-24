/***********************************************************************
 * Module:  Operacija.cs
 * Purpose: Definition of the Class Operacija
 ***********************************************************************/

using Model.Doctor;
using Model.Manager;
using System;

namespace Model.Secretary
{
   public class MedicalOperation
   {
        public long Id { get; set; }
        public int UrgencyLevel { get; set; }
        public bool Done { get; set; } = false;
        public Appointment Appointment { get; set; }
        public ReferralLetter ReferralLetter { get; set; }
        public Specialist Specialist { get; set; }
        public RecoveryRoom recoveryRoom { get; set; }
      
      /// <summary>
      /// Property for Model.Manager.RecoveryRoom
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Model.Manager.RecoveryRoom RecoveryRoom
      {
         get
         {
            return recoveryRoom;
         }
         set
         {
            if (this.recoveryRoom == null || !this.recoveryRoom.Equals(value))
            {
               if (this.recoveryRoom != null)
               {
                  Model.Manager.RecoveryRoom oldRecoveryRoom = this.recoveryRoom;
                  this.recoveryRoom = null;
                  oldRecoveryRoom.RemoveMedicalOperation(this);
               }
               if (value != null)
               {
                  this.recoveryRoom = value;
                  this.recoveryRoom.AddMedicalOperation(this);
               }
            }
         }
      }
      public MedicalOperation(long id,int level,bool done,Appointment appointment,ReferralLetter referral,RecoveryRoom room)
        {
            Id = id;
            UrgencyLevel = level;
            Done = done;
            Appointment = appointment;
            ReferralLetter = referral;
            RecoveryRoom = room;
        }

        public MedicalOperation(long id)
        {
            Id = id;
        }
   }
}