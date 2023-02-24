/***********************************************************************
 * Module:  Sekretar.cs
 * Purpose: Definition of the Class Sekretar
 ***********************************************************************/

using Model.Patient;
using System;

namespace Model.Secretary
{
    public class Secretary : Model.User.User
    {
        public Sex Sex { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Secretary(User.User user) : base(user) { }

        public Secretary(User.User user,Sex sex,MaritalStatus maritalStatus) : base(user)
        {
            Sex = sex;
            MaritalStatus = maritalStatus;

        }

        public Secretary (string jmbg,Sex sex,MaritalStatus marital): base(jmbg)
        {
            Sex = sex;
            MaritalStatus = marital;
        }
    }
    
}