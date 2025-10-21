using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models.ViewModels
{
    public class OptionViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
