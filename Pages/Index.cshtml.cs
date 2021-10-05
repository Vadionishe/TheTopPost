using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace WebApp.Pages
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

    public class IndexModel : PageModel
    {
        [BindProperty(Name = "pageCurrent", SupportsGet = true)]
        public int PageCurrent { get; set; }
        public int PageCount { get; set; }     
        public int PageItemCount { get; set; }
        public int MaxPageVisible { get; set; }
        public List<Message> DisplayMessages { get; set; }
        public List<int> Pages { get; set; }

        private IWebHostEnvironment hostingEnvironment;

        public IndexModel(IWebHostEnvironment hostingEnvironment)
        {
            MaxPageVisible = 5;
            PageItemCount = 6;           
            DisplayMessages = new List<Message>();
            this.hostingEnvironment = hostingEnvironment;

            if (!StorageMessages.isInit)
                StorageMessages.Init();
        }

        public IActionResult OnGet(int page = 1)
        {
            return OnPostTop(page);
        }

        public IActionResult OnPostTop(int page)
        {
            int endItems = StorageMessages.Messages.Count % PageItemCount;

            PageCurrent = page;
            PageCount = StorageMessages.Messages.Count / PageItemCount;
            Pages = new List<int>();

            if (endItems > 0)
                PageCount++;

            for (int i = 0; i < PageCount; i++)
                Pages.Add(i + 1);

            if (PageCount > MaxPageVisible)
            {
                int oneSidePages = MaxPageVisible / 2;
                int startPages = page - oneSidePages;

                Pages = new List<int>();

                for (int i = 0; i < MaxPageVisible; i++)
                    Pages.Add(startPages + i);

                Pages = Pages.Where(p => p > 0 && p < PageCount + 1).ToList();
            }

            StorageMessages.Messages.Sort((x, y) => y.Raiting.CompareTo(x.Raiting));

            DisplayMessages = StorageMessages.Messages.Skip((page - 1) * PageItemCount).Take(PageItemCount).ToList();

            return Page();
        }

        public IActionResult OnPostUpRaiting(long id, int page)
        {
            Message message = StorageMessages.Messages.Find(m => m.Id == id);

            if (message != null)
            {
                message.Raiting++;
            }

            return RedirectToPagePreserveMethod("Index", "Top", new { page });
        }

        public IActionResult OnPostDownRaiting(long id, int page)
        {
            Message message = StorageMessages.Messages.Find(m => m.Id == id);

            if (message != null)
            {
                message.Raiting--;
            }

            return RedirectToPagePreserveMethod("Index", "Top", new { page });
        }

        public async Task<IActionResult> OnPostSend(string message, IFormFile image)
        {
            if (image != null)
            {
                var path = Path.Combine(hostingEnvironment.WebRootPath, "images", image.FileName);

                if (System.IO.File.Exists(path))
                    path = Path.Combine(hostingEnvironment.WebRootPath, "images", $"{DateTime.Now.Ticks}_{image.FileName}");

                var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);
            }

            StorageMessages.Messages.Insert(0, new Message
            {
                Id = DateTime.Now.Ticks,
                Text = message,
                NameImage = image?.FileName
            });

            return Redirect("/");
        }

        public IActionResult OnPostDelete(long index)
        {
            Message message = StorageMessages.Messages.Find(x => x.Id == index);

            if (message != null)
                StorageMessages.Messages.Remove(message);

            return Redirect("/");
        }
    }
}