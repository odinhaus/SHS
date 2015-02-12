using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SHS.Models
{
    public enum Industry
    {
        Healthcare = 1,
        Information_Technology = 2,
        Finances = 3,
        Academic = 4,
        Other = 5
    }

    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Industry Industry { get; set; }
        [Required]
        public int Rating { get; set; }
        public string Feature { get; set; }
        public string Improve { get; set; }
        public string UserFeedback { get; set; }
    }
}