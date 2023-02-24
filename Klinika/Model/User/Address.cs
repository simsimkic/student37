// File:    Address.cs
// Created: Tuesday, April 7, 2020 4:29:35 PM
// Purpose: Definition of Class Address

using System;

namespace Model.User
{
   public class Address
   {
        public Address(long id, string streetAndNumber="")
        {
            Id = id;
            StreetAndNumber = streetAndNumber;
        }

        public long Id { get; set; }
        public string StreetAndNumber { get; set; }
        public City City { get; set; }
   
   }
}