using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public class PredmetQuiz
    {
        [Key]
        public int PredmetQuizId { get; set; }
        
        [ForeignKey("Predmet")]
        public int PredmetId { get; set; }
        public virtual Predmet Predmet { get; set; }
        
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
        
        // Additional properties if needed
        public bool IsRequired { get; set; } = false;
        public int Weight { get; set; } = 1; // For weighted scoring if needed
    }
} 