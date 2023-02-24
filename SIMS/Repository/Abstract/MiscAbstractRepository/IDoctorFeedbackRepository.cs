// File:    IDoctorFeedbackRepository.cs
// Created: 23. maj 2020 14:07:20
// Purpose: Definition of Interface IDoctorFeedbackRepository

using System;
using System.Collections.Generic;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.MiscAbstractRepository
{
    public interface IDoctorFeedbackRepository : IRepository<DoctorFeedback, long>
    {
        IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor);

        DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor);

    }
}