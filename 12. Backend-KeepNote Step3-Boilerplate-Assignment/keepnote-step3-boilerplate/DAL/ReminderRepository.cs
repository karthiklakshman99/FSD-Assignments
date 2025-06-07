using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class ReminderRepository : IReminderRepository
    {
        private readonly KeepDbContext _dbContext;
        public ReminderRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            if (reminder == null)
                throw new ArgumentNullException(nameof(reminder));

            reminder.ReminderCreationDate = DateTime.UtcNow;
            _dbContext.Reminders.Add(reminder);
            _dbContext.SaveChanges();
            return reminder;
        }
        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            var reminder = _dbContext.Reminders.FirstOrDefault(x => x.ReminderId == reminderId);
            if (reminder == null)
            {
                return false;
            }

            _dbContext.Reminders.Remove(reminder);
            _dbContext.SaveChanges();
            return true;
        }
        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(int userId)
        {
            return _dbContext.Reminders.Where(c => c.User.UserId == userId).ToList();
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            return _dbContext.Reminders.FirstOrDefault(c => c.ReminderId == reminderId);
        }
        // This method should be used to update a existing reminder.
        public bool UpdateReminder(Reminder reminder)
        {
            if (reminder == null)
            {
                throw new ArgumentNullException(nameof(reminder));
            }

            var existingReminder = _dbContext.Reminders.FirstOrDefault(c => c.ReminderId == reminder.ReminderId);
            if (existingReminder == null)
            {
                return false;
            }

            existingReminder.ReminderDescription = reminder.ReminderDescription;
            existingReminder.ReminderName = reminder.ReminderName;
            existingReminder.ReminderType = reminder.ReminderType;
            existingReminder.ReminderCreatedBy = reminder.ReminderCreatedBy;
            existingReminder.ReminderCreationDate = reminder.ReminderCreationDate;

            _dbContext.Entry(existingReminder).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
