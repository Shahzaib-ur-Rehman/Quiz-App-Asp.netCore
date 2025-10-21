using Microsoft.AspNetCore.Mvc;
using QuizApp.Data;
using QuizApp.Models.ViewModels;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public QuizController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var list = dbContext.Questions.Select(q => new QuestionViewModel()
            {
                Id = q.Id,
                Text = q.Text,
                Options =  q.Options.Select(o => new OptionViewModel()
                {
                    Id = o.Id,
                    Text = o.Text,
                }).ToList(),
            }).ToList();

            var viewModel = new QuizViewModel()
            {
                Questions =list
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult TakeQuiz(QuizViewModel model)
        {
            int Score = 0;
            int totalScore = dbContext.Questions.Count();

            foreach (var question in model.Questions)
            {
                var correctOption = dbContext.Questions.Where(q => q.Id == question.Id).Select(c=>c.CorrectOption).FirstOrDefault();
                if (question.SelectedOption==correctOption)
                {
                    Score++;
                }
            }
            ViewBag.Score = Score;
            ViewBag.TotalScore= totalScore;
            return View("Result");
        }
    }
}
