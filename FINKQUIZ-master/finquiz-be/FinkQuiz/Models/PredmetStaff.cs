using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public class PredmetStaff
    {
        [Key]
        public int PredmetStaffId { get; set; }
        
        [ForeignKey("Professor")]
        public string ProfessorId { get; set; }
        public virtual Staff Professor { get; set; }
        
        [ForeignKey("Predmet")]
        public int PredmetId { get; set; }
        public virtual Predmet Predmet { get; set; }
        
        // Additional properties
        public bool IsPrimaryProfessor { get; set; } = false;
        public string Role { get; set; } // e.g., "Lecturer", "Assistant", "Lab Instructor"
    }
} 