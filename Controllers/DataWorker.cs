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

        public static bool UseSendCode(SendCode sendCodeUse)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                SendCode sendCode = db.SendCodes.FirstOrDefault(c => c.Id == sendCodeUse.Id);

                if (sendCode != null)
                {
                    sendCode.IsUsed = true;

                    db.SaveChanges();

                    return true;
                }
            }

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
                    Text = message.Text
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
    }
}
