using System;
using System.Collections.Generic;
using System.Linq;
using ReminderService.Exceptions;
using ReminderService.Models;
using ReminderService.Repository;

namespace ReminderService.Service
{
    public class ReminderServices : IReminderService
    {
        private IReminderRepository _reminderRepository;
        public ReminderServices(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public Reminder CreateReminder(Reminder reminder)
        {
            if (reminder == null)
                throw new ArgumentException("Reminder cannot be null");

            return _reminderRepository.CreateReminder(reminder);
        }

        public bool DeleteReminder(int reminderId)
        {
            var category = _reminderRepository.GetReminderById(reminderId);
            if (category == null)
                throw new ReminderNotFoundException($"Reminder with ID {reminderId} not found");

            return _reminderRepository.DeleteReminder(reminderId);
        }
        
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty");

            return _reminderRepository.GetAllRemindersByUserId(userId);
        }
        
        public Reminder GetReminderById(int reminderId)
        {
            var category = _reminderRepository.GetReminderById(reminderId);
            if (category == null)
                throw new ReminderNotFoundException($"Reminder with ID {reminderId} not found");

            return category;
        }
        
        public bool UpdateReminder(int reminderId, Reminder reminder)
        {
            if (reminder == null)
                throw new ArgumentException("Reminder cannot be null");

            var existingReminder = _reminderRepository.GetReminderById(reminderId);
            if (existingReminder == null)
                throw new ReminderNotFoundException($"Reminder with ID {reminderId} not found");

            return _reminderRepository.UpdateReminder(reminderId, reminder);
        }
    }
}
