using System;
using System.Collections.Generic;
using System.Linq;
using NoteService.Models;
using NoteService.Repository;
using InfraSetup;
using Xunit;

namespace RepositoryTest
{
    [TestCaseOrderer("InfraSetup.PriorityOrderer", "commander")]
    public class NoteRepositoryTest : IClassFixture<NoteDbFixture>
    {
        NoteDbFixture fixture;
        private readonly INoteRepository repository;

        public NoteRepositoryTest(NoteDbFixture _fixture)
        {
            this.fixture = _fixture;
            repository = new NoteRepository(fixture.context);
        }

        [Fact, TestPriority(1)]
        public void CreateNoteShouldReturnTrue()
        {
            var note = new Note
            {
                Id = 101,
                Reminders = this.GetReminder(),
                CreationDate = DateTime.Now
            };

            var actual = repository.CreateNote(note);
            Assert.True(actual);

            List<Note> notes = repository.FindAllNotesByUser("Mukesh");
            Assert.Contains(notes, n => n.Title == "IPL 2018");
        }

        [Fact, TestPriority(2)]
        public void DeleteNoteShouldReturnTrue()
        {
            string userId = "Mukesh";
            int noteId = 102;

            var actual = repository.DeleteNote(userId, noteId);
            Assert.True(actual);

            List<Note> notes = repository.FindAllNotesByUser(userId);
            var note = notes.FirstOrDefault(n => n.Id == noteId);

            Assert.Null(note);
        }

        [Fact, TestPriority(3)]
        public void UpdateNoteShouldReturnTrue()
        {
            string userId = "Sachin";
            int noteId = 101;

            var note = new Note
            {
                Id = noteId,
                Reminders = this.GetReminder(),
                CreationDate = DateTime.Now
            };

            var actual = repository.UpdateNote(noteId, userId, note);
            Assert.True(actual);
        }

        [Fact, TestPriority(4)]
        public void FindAllShouldReturnAList()
        {
            string userId = "Mukesh";

            var actual = repository.FindAllNotesByUser(userId);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<List<Note>>(actual);
        }

        private Category GetCategory()
        {
            return new Category
            {
                Id = 201,
                CreationDate = DateTime.Now
            };
        }

        private List<Reminder> GetReminder()
        {
            return new List<Reminder>
            {
                new Reminder
                {
                    Id = 301,
                    Name = "Reminder 1",
                    Description = "Description 1",
                    Type = "Email",
                    CreationDate = DateTime.Now
                },
                new Reminder
                {
                    Id = 302,
                    Name = "Reminder 2",
                    Description = "Description 2",
                    Type = "SMS",
                    CreationDate = DateTime.Now
                }
            };
        }
    }
}

