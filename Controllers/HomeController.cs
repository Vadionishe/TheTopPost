using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using TheTopPost.Models;

namespace TheTopPost.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index(int? page)
        {
            return Top(page);
        }

        [HttpGet]
        public IActionResult Top(int? page)
        {
            page = page ?? 1;
           
            PagesTopModel model = new PagesTopModel();
            List<Message> messages = DataWorker.GetAllMessage();
            int endItems = messages.Count % model.PageItemCount;

            model.PageCurrent = (int)page;
            model.PageCount = messages.Count / model.PageItemCount;
            model.Pages = new List<int>();

            if (endItems > 0)
                model.PageCount++;

            for (int i = 0; i < model.PageCount; i++)
                model.Pages.Add(i + 1);

            if (model.PageCount > model.MaxPageVisible)
            {
                int oneSidePages = model.MaxPageVisible / 2;
                int startPages = (int)page - oneSidePages;

                model.Pages = new List<int>();

                for (int i = 0; i < model.MaxPageVisible; i++)
                    model.Pages.Add(startPages + i);

                model.Pages = model.Pages.Where(p => p > 0 && p < model.PageCount + 1).ToList();
            }

            messages.Sort((x, y) => y.Raiting.CompareTo(x.Raiting));

            model.DisplayMessages = messages.Skip(((int)page - 1) * model.PageItemCount).Take(model.PageItemCount).ToList();

            if (page < 1 || page > model.PageCount)
                return View("PageNotFound");

            return View("Top", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ValidateRecaptcha]
        [HttpPost]
        public IActionResult UpRaiting(long id, int page)
        {
            if (ModelState.IsValid)
                DataWorker.ChangeRaiting(1, id);

            return Top(page);
        }

        [ValidateRecaptcha]
        [HttpPost]
        public IActionResult DownRaiting(long id, int page)
        {
            if (ModelState.IsValid)
                DataWorker.ChangeRaiting(-1, id);

            return Top(page);
        }

        [HttpPost]
        public IActionResult CapchaConfirm(long id, int page, TypeChange typeChange)
        {
            ChangerRaitingModel model = new ChangerRaitingModel
            {
                Id = id,
                Page = page,
                TypeChange = typeChange
            };

            return View(model);
        }
    }
}
