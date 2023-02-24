﻿// File:    RoomService.cs
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class RoomService

using System;
using System.Runtime.Serialization;

namespace SIMS.Service.HospitalManagementService
{
    [Serializable]
    internal class RoomServiceException : Exception
    {
        public RoomServiceException()
        {
        }

        public RoomServiceException(string message) : base(message)
        {
        }

        public RoomServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoomServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}