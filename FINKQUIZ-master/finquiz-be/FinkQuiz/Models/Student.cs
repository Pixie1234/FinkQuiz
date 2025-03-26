using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public class Student : User
    {
        // Properties specific to students
        public string StudentId { get; set; }
        
        // Navigation properties
        public virtual ICollection<CompletedQuiz> CompletedQuizzes { get; set; } = new List<CompletedQuiz>();
        public virtual ICollection<PredmetStudent> Subjects { get; set; } = new List<PredmetStudent>();
    }
} 