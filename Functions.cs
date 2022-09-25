using AutomationPractice;
using OpenQA.Selenium;
using System.Net.Mail;

namespace AutomationPractice
{
    internal class Functions
    {
        public static string SendEmailAttachment(string subject, string body)
        {
            string message = "",
                username = "uske.uske@gmail.com",
                password = "uske123?";


            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("uske.uske@gmail.com");
                mail.To.Add("uske.uske@gmail.com");
                mail.Subject = subject;
                mail.Body = body;

                System.Net.Mail.Attachment attachment;

                DirectoryInfo d = new DirectoryInfo(@"C:/Screenshot/");
                FileInfo[] Files = d.GetFiles("*.jpeg", SearchOption.AllDirectories);

                foreach (FileInfo file in Files)
                {
                    attachment = new System.Net.Mail.Attachment(file.FullName);
                    mail.Attachments.Add(attachment);
                }

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                mail.Dispose();

            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            return message;
        }

        public static void TakeScreenShot()
        {
            Random r = new Random();

            ((ITakesScreenshot)Driver.Instance).GetScreenshot().SaveAsFile("C:/ScreenShot/" + "/Screenshot" + r.Next(0, 100000) + DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".jpeg", ScreenshotImageFormat.Jpeg);
        }
    }
}
