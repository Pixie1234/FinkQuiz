using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public class PredmetStudent
    {
        [Key]
        public int PredmetStudentId { get; set; }
        
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        
        [ForeignKey("Predmet")]
        public int PredmetId { get; set; }
        public virtual Predmet Predmet { get; set; }
        
        // You can add additional properties like enrollment date, grade, etc.
        public int? Grade { get; set; }
        public bool HasPassed { get; set; } = false;
    }
} 