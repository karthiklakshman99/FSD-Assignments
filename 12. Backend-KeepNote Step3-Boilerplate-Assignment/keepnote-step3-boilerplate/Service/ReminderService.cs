using System;
using System.Collections.Generic;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;
        /*
        Use constructor Injection to inject all required dependencies.
        */
        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository ?? throw new ArgumentNullException(nameof(reminderRepository));
        }

        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            if(reminder == null)
            {
                throw new ReminderNotFoundException(nameof(reminder));
            }

            return _reminderRepository.CreateReminder(reminder);
        }

        //This method should be used to delete an existing reminder.
        public bool DeleteReminder(int reminderId)
        {
            var reminder = _reminderRepository.GetReminderById(reminderId);
            return reminder != null ? _reminderRepository.DeletReminder(reminderId) : throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
        }

        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(int userId)
        {
            return _reminderRepository.GetAllRemindersByUserId(userId);
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            var reminder = _reminderRepository.GetReminderById(reminderId);
            return reminder ?? throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
        }

        // This method should be used to update a existing reminder.
        public bool UpdateReminder(int reminderId, Reminder reminder)
        {
            if (reminder == null)
            {
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }

            _ = _reminderRepository.GetReminderById(reminderId) ?? throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");

            return _reminderRepository.UpdateReminder(reminder);
        }
    }
}
