using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using TheTopPost.Models;

namespace TheTopPost.Controllers
{
    public class MainController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index(int? page)
        {
            return Top(page);
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Top(int? page)
        {
            page = page ?? 1;
           
            PagesTopModel model = new PagesTopModel();
            List<Message> messages = DataWorker.GetAllMessage();
            int endItems = messages.Count % model.PageItemCount;

            if (messages.Count == 0)
                return View("InfoPage", new InfoModel { Info = "No posts yet ._." });

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
                return View("InfoPage", new InfoModel { Info = "Page not found :c" });

            return View(nameof(Top), model);
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

            return RedirectToAction(nameof(Top), new { page });
        }

        [ValidateRecaptcha]
        [HttpPost]
        public IActionResult DownRaiting(long id, int page)
        {
            if (ModelState.IsValid)
                DataWorker.ChangeRaiting(-1, id);

            return RedirectToAction(nameof(Top), new { page });
        }

        [ValidateRecaptcha]
        [HttpPost]
        public IActionResult SendPost(IFormFile image, string textPost, string codePost)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(textPost) && !string.IsNullOrEmpty(codePost))
            {
                if (DataWorker.UseSendCode(new SendCode { Code = codePost }, out string info))
                {
                    string mime = null;
                    byte[] bytesImage = null;

                    if (image != null)
                    {
                        using (var stream = image.OpenReadStream())
                        {
                            using (Image _image = Image.Load(stream))
                            {
                                try
                                {
                                    mime = image.ContentType;
                                    bytesImage = GetResizedBytesImage(_image, 100);
                                }
                                catch (Exception e)
                                {
                                    _logger.LogWarning(e.Message);
                                }
                            }
                        }
                    }
                   
                    Message message = new Message
                    {
                        ImageMimeType = mime,
                        BytesImage = bytesImage,
                        Code = codePost,
                        Date = DateTime.Now.ToString("MM.dd.yyyy"),
                        Ip = HttpContext.Connection.RemoteIpAddress.ToString(),
                        NameImage = "Name Image",
                        Raiting = 0,
                        Text = textPost
                    };

                    DataWorker.CreateMessage(message);

                    return View("InfoPage", new InfoModel { Info = "Your post has been successfully created! c:" });
                }

                return View("InfoPage", new InfoModel { Info = $"Failed to send message :c\n{info}" });
            }

            return View("InfoPage", new InfoModel { Info = "Failed to send message :c\nCheck entered data" });          
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

        public FileContentResult GetImage(long postId)
        {
            Message message = DataWorker.GetAllMessage().FirstOrDefault(m => m.Id == postId);

            if (message != null && message.ImageMimeType != null && message.BytesImage != null)
                return File(message.BytesImage, message.ImageMimeType);
               
            return null;
        }

        private byte[] GetResizedBytesImage(Image image, int maxWidth)
        {
            using (var writeStream = new MemoryStream())
            {
                if (image.Width > maxWidth)
                {
                    var thumbScaleFactor = maxWidth / image.Width;
                    image.Mutate(i => i.Resize(maxWidth, image.Height *
                        thumbScaleFactor));
                }

                image.SaveAsPng(writeStream);

                return writeStream.ToArray();
            }
        }
    }
}
