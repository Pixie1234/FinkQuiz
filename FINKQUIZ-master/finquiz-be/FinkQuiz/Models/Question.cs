using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public abstract class Question
    {
        [Key]
        public int QuestionId { get; set; }
        
        [Required]
        public string QuestionText { get; set; }
        
        public int Points { get; set; } = 1;
        
        public int OrderIndex { get; set; } // For ordering questions within a quiz
        
        // Foreign key for Quiz
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
        
        // Discriminator for TPH inheritance
        [Required]
        public string QuestionType { get; set; }
    }
} 