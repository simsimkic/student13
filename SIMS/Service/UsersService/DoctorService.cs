// File:    DoctorService.cs
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class DoctorService

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SIMS.Exceptions;
using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Service.MedicalService;
using SIMS.Util;

namespace SIMS.Service.UsersService
{
    public class DoctorService : IService<Doctor, UserID>
    {
        private UserRepository _userRepository;
        private DoctorRepository _doctorRepository;
        private UserValidation _userValidation;
        private AppointmentService _appointmentService;

        public DoctorService(DoctorRepository doctorRepository,UserRepository userRepository, AppointmentService appointmentService)
        {
            _doctorRepository = doctorRepository;
            _appointmentService = appointmentService;
            _userValidation = new UserValidation();
            _userRepository = userRepository;
        }

        public IEnumerable<Doctor> GetActiveDoctors()
        {
            var doctors = _doctorRepository.GetAllEager();
            TimeInterval time = new TimeInterval(DateTime.Now, DateTime.Now.AddMinutes(10));  // Note (Gergo) : Gets doctors who are going to be at work in the next 10 minutes
            return GetWorkingDoctors(doctors, time);
        }

        private IEnumerable<Doctor> GetWorkingDoctors(IEnumerable<Doctor> doctors, TimeInterval time)
        {
            List<Doctor> workingDoctors = new List<Doctor>();

            WorkingDaysEnum dayOfWeek = GetDayOfWeek(time.StartTime.DayOfWeek);

            foreach (Doctor d in doctors)
            {
                if(d.TimeTable.WorkingHours.ContainsKey(dayOfWeek))
                    if (d.TimeTable.WorkingHours[dayOfWeek].IsTimeBetween(time))
                        workingDoctors.Add(d);
            }

            return workingDoctors;
        }

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _doctorRepository.GetDoctorByType(doctorType);

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(TimeInterval timeInterval)
        {
            var appointments = _appointmentService.GetAppointmentsByTime(timeInterval).Where(ap => !ap.Canceled);
            var doctors = _doctorRepository.GetAllEager();

            RemoveUnavailableDoctors(doctors, appointments);
            return GetWorkingDoctors(doctors, timeInterval);
        }

        private void RemoveUnavailableDoctors(IEnumerable<Doctor> doctors, IEnumerable<Appointment> appointments)
        {
            foreach (Appointment a in appointments)
            {
                if (a.DoctorInAppointment != null)
                {
                    doctors = doctors.Where(d => !d.GetId().Equals(a.DoctorInAppointment.GetId()));
                }
            }
        }

        public IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter)
            => _doctorRepository.GetFilteredDoctors(filter);

        public IEnumerable<Doctor> GetAll()
            => _doctorRepository.GetAllEager();

        public Doctor GetByID(UserID id)
            => _doctorRepository.GetEager(id);

        public Doctor Create(Doctor entity)
        {
            Validate(entity);
            return _doctorRepository.Create(entity);
        }

        public void Delete(Doctor entity)
            => _doctorRepository.Delete(entity);
        
        public void Validate(Doctor user)
            => _userValidation.Validate(user);

        public void Update(Doctor entity)
            => _doctorRepository.Update(entity);

        private WorkingDaysEnum GetDayOfWeek(DayOfWeek day)
        {
           switch(day)
           {
                case DayOfWeek.Monday:
                    return WorkingDaysEnum.MONDAY;
                case DayOfWeek.Tuesday:
                    return WorkingDaysEnum.TUESDAY;
                case DayOfWeek.Wednesday:
                    return WorkingDaysEnum.WEDNESDAY;
                case DayOfWeek.Thursday:
                    return WorkingDaysEnum.THURSDAY;
                case DayOfWeek.Friday:
                    return WorkingDaysEnum.FRIDAY;
                case DayOfWeek.Saturday:
                    return WorkingDaysEnum.SATURDAY;
                default:
                    return WorkingDaysEnum.SUNDAY;
           };
        }
    }
}