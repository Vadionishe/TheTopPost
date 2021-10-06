using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheTopPost.Models;

namespace TheTopPost.Controllers
{
    public static class StorageMessages
    {
        public static bool isInit;
        public static List<Message> Messages { get; set; }

        public static void Init()
        {
            Messages = new List<Message>();

            for (int i = 0; i < 50; i++)
            {
                Messages.Add(new Message
                {
                    Id = i,
                    Date = "21.04.2021",
                    Ip = "243243",
                    NameImage = "123.jpeg",
                    Raiting = i,
                    Text = "1egr gre weg we gewrg wrgwergwerg wergwergwrthpos9[fhwrty wrtohirethy"
                });
            }

            isInit = true;
        }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            if (!StorageMessages.isInit)
                StorageMessages.Init();
        }

        public IActionResult Index(int? page)
        {
            page = page ?? 1;

            PagesTopModel model = new PagesTopModel();
            int endItems = StorageMessages.Messages.Count % model.PageItemCount;

            model.PageCurrent = (int)page;
            model.PageCount = StorageMessages.Messages.Count / model.PageItemCount;
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

            StorageMessages.Messages.Sort((x, y) => y.Raiting.CompareTo(x.Raiting));

            model.DisplayMessages = StorageMessages.Messages.Skip(((int)page - 1) * model.PageItemCount).Take(model.PageItemCount).ToList();

            return View(model);
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

        //public IActionResult OnPostUpRaiting(long id, int page)
        //{
        //    Message message = StorageMessages.Messages.Find(m => m.Id == id);

        //    if (message != null)
        //    {
        //        message.Raiting++;
        //    }

        //    return RedirectToPagePreserveMethod("Index", "Top", new { page });
        //}

        //public IActionResult OnPostDownRaiting(long id, int page)
        //{
        //    Message message = StorageMessages.Messages.Find(m => m.Id == id);

        //    if (message != null)
        //    {
        //        message.Raiting--;
        //    }

        //    return RedirectToPagePreserveMethod("Index", "Top", new { page });
        //}
    }
}
