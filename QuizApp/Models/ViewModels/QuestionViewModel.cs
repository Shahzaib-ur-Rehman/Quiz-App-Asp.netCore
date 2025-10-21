using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models.ViewModels
{
    public class QuestionViewModel
    {
        
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }


        [Required]
        public List<OptionViewModel> Options { get; set; }
        public Guid? SelectedOption { get; set; } // for user's selected answer


    }
}
