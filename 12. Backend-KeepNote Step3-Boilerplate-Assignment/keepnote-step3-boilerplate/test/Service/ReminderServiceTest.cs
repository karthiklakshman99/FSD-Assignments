using System.Collections.Generic;
using DAL;
using Entities;
using Exceptions;
using Moq;
using Service;
using Xunit;
using System;

namespace Test.Service
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class ReminderServiceTest
    {
        #region positive tests
        [Fact, TestPriority(3)]
        public void CreateReminderShouldReturnReminder()
        {
            var mockRepo = new Mock<IReminderRepository>();
            Reminder reminder = new Reminder { ReminderName = "SMS", ReminderDescription = "SMS reminder", ReminderType = "notification", ReminderCreatedBy = 8105845 };

            mockRepo.Setup(repo => repo.CreateReminder(reminder)).Returns(reminder);
            var service = new ReminderService(mockRepo.Object);

            var actual = service.CreateReminder(reminder);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Reminder>(actual);
        }

        [Fact, TestPriority(4)]
        public void DeleteReminderShouldReturnTrueButThrowsException()
        {
            var mockRepo = new Mock<IReminderRepository>();
            int Id = 2;
            mockRepo.Setup(repo => repo.DeletReminder(Id)).Returns(true);
            var service = new ReminderService(mockRepo.Object);

            var actual = Assert.Throws<ReminderNotFoundException>(() => service.DeleteReminder(Id));

            Assert.Equal($"Reminder with id: {Id} does not exist", actual.Message);
        }
        [Fact, TestPriority(1)]
        public void GetAllRemindersShouldReturnAList()
        {
            var userId = 8105845;
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetAllRemindersByUserId(userId)).Returns(this.GetReminders());
            var service = new ReminderService(mockRepo.Object);

            var actual = service.GetAllRemindersByUserId(userId);

            Assert.IsAssignableFrom<List<Reminder>>(actual);
            Assert.NotEmpty(actual);
        }

        [Fact, TestPriority(2)]
        public void GetReminderByIdShouldReturnAReminder()
        {
            int Id = 1;
            Reminder reminder = new Reminder {ReminderId=1, ReminderName = "Email", ReminderDescription = "Email reminder", ReminderType = "notification", ReminderCreatedBy = 8105845 };
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminderById(Id)).Returns(reminder);
            var service = new ReminderService(mockRepo.Object);

            var actual = service.GetReminderById(Id);

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Reminder>(actual);
        }

        [Fact, TestPriority(5)]
        public void UpdateReminderShouldReturnTrue()
        {
            int Id = 1;
            Reminder reminder = new Reminder { ReminderId = 1, ReminderName = "Sports", ReminderCreatedBy = 8105845, ReminderDescription = "sports reminder", ReminderCreationDate = new DateTime(), ReminderType = "sms" };
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminderById(Id)).Returns(reminder);
            mockRepo.Setup(repo => repo.UpdateReminder(reminder)).Returns(true);
            var service = new ReminderService(mockRepo.Object);

            var actual = service.UpdateReminder(Id, reminder);
            Assert.True(actual);
        }
        private List<Reminder> GetReminders()
        {
            List<Reminder> reminders = new List<Reminder> {
               new Reminder {ReminderName= "Email", ReminderDescription= "Email reminder", ReminderType= "notification", ReminderCreatedBy=8105845 }
            };

            return reminders;
        }

        #endregion positive tests

        #region negative tests

        [Fact, TestPriority(6)]
        public void DeleteReminderShouldThrowException()
        {
            var mockRepo = new Mock<IReminderRepository>();
            int Id = 2;
            mockRepo.Setup(repo => repo.DeletReminder(Id)).Returns(false);
            var service = new ReminderService(mockRepo.Object);

            var actual = Assert.Throws<ReminderNotFoundException>(() => service.DeleteReminder(Id));

            Assert.Equal($"Reminder with id: {Id} does not exist", actual.Message);
        }
        [Fact, TestPriority(7)]
        public void GetAllRemindersShouldReturnEmptyList()
        {
            int userId = 8105847;
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetAllRemindersByUserId(userId)).Returns(new List<Reminder>());
            var service = new ReminderService(mockRepo.Object);

            var actual = service.GetAllRemindersByUserId(userId);

            Assert.IsAssignableFrom<List<Reminder>>(actual);
            Assert.Empty(actual);
        }

        [Fact, TestPriority(8)]
        public void GetReminderByIdShouldThrowException()
        {
            int Id = 2;
            Reminder reminder = null;
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminderById(Id)).Returns(reminder);
            var service = new ReminderService(mockRepo.Object);

            var actual = Assert.Throws<ReminderNotFoundException>(() => service.GetReminderById(Id));

            Assert.Equal($"Reminder with id: {Id} does not exist", actual.Message);
        }

        [Fact, TestPriority(9)]
        public void UpdateReminderShouldThrowException()
        {
            int Id = 2;
            Reminder reminder = new Reminder { ReminderName = "SMS", ReminderDescription = "SMS reminder", ReminderType = "notification", ReminderCreatedBy = 8105845 };
            Reminder _reminder = null;
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminderById(Id)).Returns(_reminder);
            mockRepo.Setup(repo => repo.UpdateReminder(reminder)).Returns(false);
            var service = new ReminderService(mockRepo.Object);


            var actual = Assert.Throws<ReminderNotFoundException>(() => service.UpdateReminder(Id, reminder));
            Assert.Equal($"Reminder with id: {Id} does not exist", actual.Message);
        }

        #endregion negative tests
    }
}
