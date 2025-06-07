using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities
{
    [Table("Reminder")]
    public class Reminder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReminderId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ReminderName { get; set; }
        [MaxLength(500)]
        public string ReminderDescription { get; set; }
        [MaxLength(50)]
        public string ReminderType { get; set; }
        [Required]
        public int ReminderCreatedBy { get; set; }
        public DateTime ReminderCreationDate { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public ICollection<Note> Notes { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
