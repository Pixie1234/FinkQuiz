using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinkQuiz.Models
{
    public class Oblast
    {
        [Key]
        public int OblastId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        // Navigation property
        public virtual ICollection<PredmetOblast> Subjects { get; set; } = new List<PredmetOblast>();
    }
} 