using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult Index()
        {
            var questions = dbContext.Questions.Include(x => x.Options)     
                .Select(static x => new QuestionItem()
                {
                    Id = x.Id,
                    Text = x.Text,
                })
                .ToList();

            return View(new QuizViewModel() { Questions = questions });
        }

        [HttpPost]
        public IActionResult Submit(List<Guid> userAnswers)
        {
            var questions = dbContext.Questions.ToList();
            var score = 0;
            var totalScore = questions.Count;

            ViewBag.Score = score;
            ViewBag.TotalScore = totalScore;

            return View("Results");
        }
    }
}
