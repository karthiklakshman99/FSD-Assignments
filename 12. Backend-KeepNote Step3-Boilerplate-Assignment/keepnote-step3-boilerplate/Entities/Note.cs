using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities
{
    [Table("Note")]
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        [Required]
        [MaxLength(200)]
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        [MaxLength(50)]
        public string NoteStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public int? ReminderId { get; set; }
        [JsonIgnore]
        public Reminder Reminder { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
