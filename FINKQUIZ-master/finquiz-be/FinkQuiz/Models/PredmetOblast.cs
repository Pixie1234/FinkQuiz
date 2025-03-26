using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    public class PredmetOblast
    {
        [Key]
        public int PredmetOblastId { get; set; }
        
        [ForeignKey("Predmet")]
        public int PredmetId { get; set; }
        public virtual Predmet Predmet { get; set; }
        
        [ForeignKey("Oblast")]
        public int OblastId { get; set; }
        public virtual Oblast Oblast { get; set; }
    }
} 