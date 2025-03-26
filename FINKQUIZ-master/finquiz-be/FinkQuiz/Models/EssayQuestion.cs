using System.ComponentModel.DataAnnotations.Schema;

namespace FinkQuiz.Models
{
    [Table("Questions")]
    public class EssayQuestion : Question
    {
        public EssayQuestion()
        {
            QuestionType = "Essay";
        }
        
        public int MaxWordCount { get; set; } = 0; // 0 for unlimited
        
        // Optional sample answer for grading reference
        public string SampleAnswer { get; set; }
    }
} 