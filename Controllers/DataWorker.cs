using System.Collections.Generic;
using System.Linq;
using TheTopPost.Models;
using TheTopPost.Models.Data;

namespace TheTopPost.Controllers
{
    public static class DataWorker
    {
        public static string DeleteSendCodes(bool onlyUsed)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var codesForDelete = onlyUsed 
                    ? db.SendCodes.Where(c => c.IsUsed == true) 
                    : db.SendCodes;

                db.SendCodes.RemoveRange(codesForDelete);
                db.SaveChanges();
            }

            return "";
        }

        public static string CreateSendCode(SendCode sendCode)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.SendCodes.Add(new SendCode
                {
                    Code = sendCode.Code,
                    IsUsed = false
                });
                db.SaveChanges();
            }

            return "";
        }

        public static bool UseSendCode(SendCode sendCodeUse, out string info)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                SendCode sendCode = db.SendCodes.FirstOrDefault(c => c.Code == sendCodeUse.Code);

                if (sendCode != null)
                {
                    if (!sendCode.IsUsed)
                    {
                        sendCode.IsUsed = true;
                        info = "Success!";

                        db.SaveChanges();

                        return true;
                    }

                    info = "The code has already been used!";
                }
            }

            info = "Code not found!";

            return false;
        }

        public static string CreateMessage(Message message)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Messages.Add(new Message
                {
                    Ip = message.Ip,
                    NameImage = message.NameImage,
                    Raiting = message.Raiting,
                    Date = message.Date,
                    Text = message.Text,
                    BytesImage = message.BytesImage,
                    ImageMimeType = message.ImageMimeType,
                    Code = message.Code
                });

                db.SaveChanges();
            }

            return "";
        }

        public static string ChangeRaiting(int value, long id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Message message = db.Messages.FirstOrDefault(m => m.Id == id);
                
                if (message != null)
                {
                    message.Raiting += value;

                    db.SaveChanges();
                }
            }

            return "";
        }

        public static List<Message> GetAllMessage()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Messages.ToList();
            }
        }

        public static Message EditMessage(Message editableMessage)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Message message = db.Messages.FirstOrDefault(m => m.Id == editableMessage.Id);

                if (message != null)
                {
                    message.BytesImage = editableMessage.BytesImage;
                    message.Code = editableMessage.Code;
                    message.Date = editableMessage.Date;
                    message.ImageMimeType = editableMessage.ImageMimeType;
                    message.Ip = editableMessage.Ip;
                    message.NameImage = editableMessage.NameImage;
                    message.Raiting = editableMessage.Raiting;
                    message.Text = editableMessage.Text;

                    db.SaveChanges();
                }

                return message;
            }
        }
    }
}
