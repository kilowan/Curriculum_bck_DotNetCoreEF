using curriculum.Data.Models;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class PasswordRecoveryData : IPasswordRecoveryData
    {
        private readonly CurriculumContext _context;
        public PasswordRecoveryData(CurriculumContext context)
        {
            _context = context;
        }
        public bool RecoverPassword(string username)
        {
            try
            {
                bool result = false;
                int number = new Random().Next();
                result = SendEmail(username, number);
                Models.User user = _context.User
                    .Include(user => user.credentials)
                    .Where(user => user.credentials.username == username)
                    .FirstOrDefault();

                if (user != null) result = AddRecoveryLog(number, user.id);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool CheckRecoverCode(string code, string username)
        {
            try
            {
                bool result = false;
                int userId = _context.User
                    .Include(User => User.credentials)
                    .Where(user => user.credentials.username == username)
                    .Select(user => user.id)
                    .FirstOrDefault();

                RecoverLog log = _context.RecoverLogs
                    .Where(logData => logData.userId == userId && logData.code == code && logData.active == true)
                    .FirstOrDefault();

                if (log != null)
                {
                    log.active = false;
                    _context.RecoverLogs.Update(log);
                    if (_context.SaveChanges() == 1) result = true;
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private bool AddRecoveryLog(int code, int userId)
        {
            bool result = false;
            int id = 1;
            RecoverLog old = _context.RecoverLogs
                .OrderBy(log => log.id)
                .LastOrDefault();
            if (old != null) id = old.id;

            _context.RecoverLogs.Add(new RecoverLog()
            {
                code = $"{ code }",
                date = DateTime.Now,
                userId = userId,
                id = id
            });

            if (_context.SaveChanges() == 1) result = true;

            return result;
        }
        private bool SendEmail(string email, int code)
        {
            try
            {
                EmailConfig mailconf = _context.EmailConfigs
                    .FirstOrDefault();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Juan", mailconf.username));
                message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", email));
                message.Subject = "Password recover";
                message.Body = new TextPart("plain")
                {
                    Text = $"Utilice este código para recuperar su cuenta: {code}"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(mailconf.host, mailconf.port, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(mailconf.username, mailconf.password);

                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
