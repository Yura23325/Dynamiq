using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPNU_Library.Models
{
    public class Issue
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [Required]
        public Guid BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime? RetDate { get; set; }
    }
}
