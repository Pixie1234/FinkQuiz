using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    [Table("Questions")]
    public class SingleChoiceQuestion : Question
    {
        public SingleChoiceQuestion()
        {
            QuestionType = "SingleChoice";
        }
        
        // Options stored as JSON or you can create a separate Options table
        public string Options { get; set; }
        
        public int CorrectOptionIndex { get; set; }
    }
} 