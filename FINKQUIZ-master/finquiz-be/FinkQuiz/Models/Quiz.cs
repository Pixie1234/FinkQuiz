using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
        
        public int TimeLimit { get; set; } // Time limit in minutes, 0 for no limit
        
        // Foreign key for Staff (creator)
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public virtual Staff Creator { get; set; }
        
        // Navigation properties
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<CompletedQuiz> CompletedQuizzes { get; set; } = new List<CompletedQuiz>();
        
        // Add this instead:
        public virtual ICollection<PredmetQuiz> Predmets { get; set; } = new List<PredmetQuiz>();
    }
} 