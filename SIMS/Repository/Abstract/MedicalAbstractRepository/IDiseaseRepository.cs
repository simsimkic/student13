// File:    IDiseaseRepository.cs
// Created: 23. maj 2020 14:03:39
// Purpose: Definition of Interface IDiseaseRepository

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.Abstract.MedicalAbstractRepository
{
    public interface IDiseaseRepository : IRepository<Disease, long>
    {
        IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms);

        IEnumerable<Disease> GetDiseasesByType(DiseaseType type);

    }
}