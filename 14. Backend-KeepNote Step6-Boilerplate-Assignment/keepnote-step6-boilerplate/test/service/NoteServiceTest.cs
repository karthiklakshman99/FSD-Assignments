using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using NoteService.Models;
using NoteService.Repository;
using NoteService.Exceptions;
using InfraSetup;

namespace ServiceTest
{
    [TestCaseOrderer("InfraSetup.PriorityOrderer", "commander")]
    public class NoteServiceTest
    {
        [Fact, TestPriority(1)]
        public void CreateNoteShouldReturnTrue()
        {
            var note = this.GetNote();
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.CreateNote(note)).Returns(true);
            var service = new NoteService.Service.NoteServices(mockRepo.Object);

            var actual = service.CreateNote(note);
            Assert.True(actual);
        }

        [Fact, TestPriority(2)]
        public void UpdateNoteShouldReturnTrue()
        {
            int noteId = 101;
            string userId = "Mukesh";
            var note = this.GetNote();
            note.Id = noteId;

            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.UpdateNote(noteId, userId, note)).Returns(true);
            var service = new NoteService.Service.NoteServices(mockRepo.Object);

            var actual = service.UpdateNote(noteId, userId, note);
            Assert.NotNull(actual);
        }

        [Fact, TestPriority(3)]
        public void DeleteNoteShouldReturnTrue()
        {
            int noteId = 101;
            string userId = "Mukesh";
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.DeleteNote(userId, noteId)).Returns(true);
            var service = new NoteService.Service.NoteServices(mockRepo.Object);

            var actual = service.DeleteNote(userId, noteId);

            Assert.True(actual);
        }

        [Fact, TestPriority(4)]
        public void GetAllNotesShouldReturnAList()
        {
            string userId = "Mukesh";
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.FindAllNotesByUser(userId)).Returns(this.GetNotes());
            var service = new NoteService.Service.NoteServices(mockRepo.Object);

            var actual = service.GetAllNotesByUserId(userId);
            Assert.NotEmpty(actual);
            Assert.IsAssignableFrom<List<Note>>(actual);
        }

        [Fact, TestPriority(5)]
        public void DeleteShouldThrowException()
        {
            int noteId = 121;
            string userId = "Mukesh";
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.DeleteNote(userId, noteId)).Returns(false);
            var service = new NoteService.Service.NoteServices(mockRepo.Object);

            var actual = Assert.Throws<NoteNotFoundException>(() => service.DeleteNote(userId, noteId));
            Assert.Equal("Note not found", actual.Message);
        }

        [Fact, TestPriority(6)]
        public void UpdateShouldThrowException()
        {
            int noteId = 121;
            string userId = "Mukesh";
            var note = this.GetNote();
            note.Id = noteId;

            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.UpdateNote(noteId, userId, note)).Returns(false);
            var service = new NoteService.Service.NoteServices(mockRepo.Object);

            var actual = Assert.Throws<NoteNotFoundException>(() => service.UpdateNote(noteId, userId, note));
            Assert.Equal("Note not found", actual.Message);
        }

        #region helper methods
        private Category GetCategory()
        {
            return new Category
            {
                Id = 201,
                Name = "Cricket",
                Description = "IPL 20-20",
                CreatedBy = "Mukesh",
                CreationDate = DateTime.Now
            };
        }

        private List<Reminder> GetReminder()
        {
            return new List<Reminder>
            { new Reminder { Id = 201, Name = "Reminder1", Description = "Description1", Type = "Type1", CreatedBy = "Mukesh", CreationDate = DateTime.Now } };
        }

        private Note GetNote()
        {
            return new Note
            {
                Id = 101,
                Reminders = this.GetReminder(),
                CreationDate = DateTime.Now
            };
        }

        private List<Note> GetNotes()
        {
            return new List<Note> { this.GetNote() };
        }
        #endregion helper methods
    }
}
