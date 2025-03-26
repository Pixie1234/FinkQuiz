using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public class Staff : User
    {
        // Properties specific to staff
        public string StaffId { get; set; }
        public string Department { get; set; }
        
        // Navigation property
        public virtual ICollection<Quiz> CreatedQuizzes { get; set; } = new List<Quiz>();
        public virtual ICollection<PredmetStaff> Subjects { get; set; } = new List<PredmetStaff>();
    }
} 