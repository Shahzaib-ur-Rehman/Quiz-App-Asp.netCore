using QuizApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models.ViewModels
{
    public class QuizViewModel
    {
        public List<QuestionViewModel> Questions { get; set; }
    }
}
