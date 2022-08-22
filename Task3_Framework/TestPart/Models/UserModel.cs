﻿using System;
using log4net;

namespace Task3_Framework
{
    public class UserModel
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string UserNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            UserModel other = (UserModel)obj; ;

            if (FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName) && Email.Equals(other.Email) &&
                Age.Equals(other.Age) && Salary.Equals(other.Salary) && Department.Equals(other.Department))
            {
                log.Info("User models are equal");
                return true;
            }
            log.Error("User models aren't  equal");
            return false;
        }

        public void SetModelFieldsFromTestData()
        {
            UserNumber = ConfigUtils.UserInfo["UserNumber"];
            FirstName = ConfigUtils.UserInfo["FirstName"];
            LastName = ConfigUtils.UserInfo["LastName"];
            Email = ConfigUtils.UserInfo["Email"];
            Age = ConfigUtils.UserInfo["Age"];
            Salary = ConfigUtils.UserInfo["Salary"];
            Department = ConfigUtils.UserInfo["Department"];

            log.Info("Successfully set user model fields");
        }
    }
}

    
