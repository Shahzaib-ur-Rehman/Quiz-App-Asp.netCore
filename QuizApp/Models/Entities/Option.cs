using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models.Entities
{
    public class Option
    {
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid QuestionId { get; set; }


    }
}
