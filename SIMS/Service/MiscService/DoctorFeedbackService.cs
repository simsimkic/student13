// File:    DoctorFeedbackService.cs
// Created: 21. maj 2020 15:04:26
// Purpose: Definition of Class DoctorFeedbackService

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SIMS.Exceptions;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.MiscRepository;

namespace SIMS.Service.MiscService
{
    public class DoctorFeedbackService : IService<DoctorFeedback, long>
    {

        private DoctorFeedbackRepository _doctorFeedbackRepository;

        public DoctorFeedbackService(DoctorFeedbackRepository doctorFeedbackRepository)
        {
            _doctorFeedbackRepository = doctorFeedbackRepository;
        }

        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
            => _doctorFeedbackRepository.GetByDoctor(doctor);

        public double GetAverageRatingByDoctor(Doctor doctor)
        {
            IEnumerable<DoctorFeedback> allFeedback = GetByDoctor(doctor);
            double sum = 0;
            int counter = 0;
            
            foreach(DoctorFeedback feedback in allFeedback)
            {
                int starsSum = 0;
                int counter1 = 0;

                foreach (Rating rating in feedback.Rating.Values)
                {
                    starsSum += rating.Stars;
                    counter1++;
                }
                sum += starsSum;
                counter += counter1;
            }

            return sum / counter;

        }

        public void Validate(DoctorFeedback doctorFeedback)
        {
            if (doctorFeedback.Doctor == null)
            {
                throw new DoctorFeedbackServiceException("DoctorFeedbackService - Doctor is null!");
            }
        }

        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
            => _doctorFeedbackRepository.GetByPatientDoctor(patient, doctor);

        public IEnumerable<DoctorFeedback> GetAll()
            => _doctorFeedbackRepository.GetAllEager();

        public DoctorFeedback GetByID(long id)
            => GetAll().SingleOrDefault(df => df.GetId() == id);

        public DoctorFeedback Create(DoctorFeedback entity)
        {
            Validate(entity);
            return _doctorFeedbackRepository.Create(entity);
        }

        public void Update(DoctorFeedback entity)
        {
            Validate(entity);
            _doctorFeedbackRepository.Update(entity);
        }

        public void Delete(DoctorFeedback entity)
            => _doctorFeedbackRepository.Delete(entity);


    }
}