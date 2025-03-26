using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    [Table("Questions")]
    public class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion()
        {
            QuestionType = "MultipleChoice";
        }
        
        // Options stored as JSON or create a separate Options table
        public string Options { get; set; }
        
        // Correct answers stored as comma-separated indices or JSON array
        public string CorrectOptionIndices { get; set; }
    }
} 