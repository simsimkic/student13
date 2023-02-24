// File:    IPersonValidation.cs
// Created: 22. maj 2020 12:07:12
// Purpose: Definition of Interface IPersonValidation

using System;

namespace SIMS.Util
{
    public interface IPersonValidation
    {
        void CheckName(string name);

        void CheckUidn(string uidn);

        void CheckDateOfBirth(DateTime date);

        void CheckEmail(string email);

        void CheckPhoneNumber(string phoneNumber);

    }
}