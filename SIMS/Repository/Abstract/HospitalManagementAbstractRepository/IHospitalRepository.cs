// File:    IHospitalRepository.cs
// Created: 23. maj 2020 13:57:57
// Purpose: Definition of Interface IHospitalRepository

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IHospitalRepository : IRepository<Hospital, long>
    {
        IEnumerable<Hospital> GetHospitalByLocation(Location location);

    }
}