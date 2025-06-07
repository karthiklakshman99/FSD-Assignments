using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        public string CategoryDescription { get; set; }
        [Required]
        public int CategoryCreatedBy { get; set; }
        public DateTime CategoryCreationDate { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public ICollection<Note> Notes { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
