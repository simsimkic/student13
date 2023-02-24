﻿// File:    DoctorRepository.cs
// Created: 24. maj 2020 17:27:33
// Purpose: Definition of Class DoctorRepository

using System;
using System.Runtime.Serialization;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    [Serializable]
    internal class NotUniqueException : Exception
    {
        public NotUniqueException()
        {
        }

        public NotUniqueException(string message) : base(message)
        {
        }

        public NotUniqueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotUniqueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}