// File:    NotificationService.cs
// Created: 7. maj 2020 12:02:54
// Purpose: Definition of Class NotificationService

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Exceptions;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.MiscRepository;

namespace SIMS.Service.MiscService
{
    public class NotificationService : IService<Notification, long>
    {

        private NotificationRepository _notificationRepository;

        public NotificationService(NotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IEnumerable<Notification> GetNotificationByUser(User user)
            => _notificationRepository.GetNotificationByUser(user);

        public IEnumerable<Notification> GetAll()
            => _notificationRepository.GetAllEager();

        public Notification GetByID(long id)
            => GetAll().SingleOrDefault(notification => notification.GetId() == id);

        public Notification Create(Notification entity)
        {
            Validate(entity);
            return _notificationRepository.Create(entity);
        }

        public void Update(Notification entity)
        {
            Validate(entity);
            _notificationRepository.Update(entity);
        }

        public void Delete(Notification entity)
            => _notificationRepository.Delete(entity);

        public void Validate(Notification entity)
        {
            if (entity.Recipient == null)
            {
                throw new NotificationServiceException("NotificationService - Recipient is not set!");
            }
        }
    }
}