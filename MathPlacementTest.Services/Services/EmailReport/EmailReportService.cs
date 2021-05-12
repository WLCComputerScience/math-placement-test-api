using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MathPlacementTest.Services
{
    public class EmailReportService : IEmailReportService
    {
        public bool EmailReport(EmailReportParams emailReportParams)
        {
            //Tests
            if (string.IsNullOrEmpty(emailReportParams.ToEmailAddress))
            {
                emailReportParams.errorMessage = "Null or empty email address";
                return false;
            }
            if (string.IsNullOrEmpty(emailReportParams.FilePath))
            {
                emailReportParams.errorMessage = "Null or empty file path";
                return false;
            }

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            
            message.From = new MailAddress("wlcmathplacement@gmail.com");
            try
            {
                message.To.Add(new MailAddress(emailReportParams.ToEmailAddress));
            }
            catch (Exception e)
            {
                emailReportParams.errorMessage = "Incorrect email address format";
                return false;
            }

            message.Subject = "Student Report";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "";
            
            try
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(emailReportParams.FilePath);
                message.Attachments.Add(attachment);
            }
            catch(Exception e)
            {
                emailReportParams.errorMessage = "File not found";
                return false;
            }

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("wlcmathplacement@gmail.com", "$12345678mp");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);

            return true;
        }
    }
}
