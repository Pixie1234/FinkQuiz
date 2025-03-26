using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinkQuiz.Models
{
    public class Predmet
    {
        [Key]
        public int PredmetId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        [StringLength(20)]
        public string Code { get; set; }
        
        public int Credits { get; set; }
        
        // Navigation properties
        public virtual ICollection<PredmetStudent> Students { get; set; } = new List<PredmetStudent>();
        public virtual ICollection<PredmetStaff> Professors { get; set; } = new List<PredmetStaff>();
        public virtual ICollection<PredmetOblast> Areas { get; set; } = new List<PredmetOblast>();
        public virtual ICollection<PredmetQuiz> Quizzes { get; set; } = new List<PredmetQuiz>();
    }
} 