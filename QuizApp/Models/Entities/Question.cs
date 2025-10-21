using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models.Entities
{
    public class Question
    {
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }


        [Required]
        public List<Option> Options { get; set; }

        [Required]
        public Guid CorrectOption { get; set; }
    }
}
