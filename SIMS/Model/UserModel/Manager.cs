/***********************************************************************
 * Module:  Manager.cs
 * Purpose: Definition of the Class Manager
 ***********************************************************************/

using System;

namespace SIMS.Model.UserModel
{
    public class Manager : Employee
    {
        public Manager(UserID id) : base(id) { }

        public Manager( string userName,
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        TimeTable timeTable, 
                        Hospital hospital) 
            : base(timeTable, hospital, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }

        public Manager(string userName,
                        string password,
                        string name,
                        string surname,
                        string middleName,
                        Sex sex,
                        DateTime dateOfBirth,
                        string uidn,
                        Address address,
                        string homePhone,
                        string cellPhone,
                        string email1,
                        string email2,
                        TimeTable timeTable,
                        Hospital hospital)
            : base(timeTable, hospital, userName, password, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }

        public Manager( UserID id, 
                        string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        TimeTable timeTable, 
                        Hospital hospital) 
            : base(id, timeTable, hospital, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }
    }
}