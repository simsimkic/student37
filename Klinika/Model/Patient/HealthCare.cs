// File:    HealthCare.cs
// Created: Tuesday, April 7, 2020 5:05:37 PM
// Purpose: Definition of Class HealthCare

using System;

namespace Model.Patient
{
   public class HealthCare
   {
        public string Workers { get; set; }
        public string WorkersMembers { get; set; }
        public string RetireeMembers { get; set; }
        public string FarmerMembers { get; set; }
        public string MilitaryMembers { get; set; }
        public string Other { get; set; }

        public HealthCare(string workers, string workersMembers, string retireeMembers, string farmerMembers, string militaryMembers, string other)
        {
            Workers = workers;
            WorkersMembers = workersMembers;
            RetireeMembers = retireeMembers;
            FarmerMembers = farmerMembers;
            MilitaryMembers = militaryMembers;
            Other = other;
        }

        public HealthCare()
        {
        }
    }
}