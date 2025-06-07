using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using ReminderService.Models;

namespace ReminderService.Repository
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly ReminderContext _context;

        public ReminderRepository(ReminderContext context)
        {
            _context = context;
        }

        public Reminder CreateReminder(Reminder reminder)
        {
            _context.Reminders.InsertOne(reminder);
            return reminder;
        }
        
        public bool DeleteReminder(int reminderId)
        {
            var result = _context.Reminders.DeleteOne(c => c.Id == reminderId);
            return result.DeletedCount > 0;
        }
        
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            return _context.Reminders.Find(c => c.CreatedBy == userId).ToList();
        }
        
        public Reminder GetReminderById(int reminderId)
        {
            return _context.Reminders.Find(c => c.Id == reminderId).FirstOrDefault();
        }
        
        public bool UpdateReminder(int reminderId, Reminder reminder)
        {
            var result = _context.Reminders.ReplaceOne(
                c => c.Id == reminderId,
                reminder
            );
            return result.ModifiedCount > 0;
        }
    }
}
