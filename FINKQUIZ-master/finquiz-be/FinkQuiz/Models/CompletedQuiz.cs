using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public class CompletedQuiz
    {
        [Key]
        public int CompletedQuizId { get; set; }
        
        // Foreign key for Student
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        
        // Foreign key for Quiz
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
        
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        
        public int Score { get; set; }
        
        // JSON string containing answers
        public string Answers { get; set; }
        
        public bool IsCompleted { get; set; } = false;
    }
} 