using MathPlacementTest.Services.Objects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MathPlacementTest.Services
{
    public class EmailReportService : IEmailReportService
    {
        public bool EmailReport(EmailReportParams emailReportParams, IAdminGenerateReportDataRetrieverService adminGenerateReportService)
        {
            AdminGenerateReportService _adminGenerateReportService = new AdminGenerateReportService(adminGenerateReportService);
            //Tests
            if (string.IsNullOrEmpty(emailReportParams.ToEmailAddress))
            {
                return false;
            }
            DateTime StartDate = DateTime.Parse(emailReportParams.StartDate);
            DateTime EndDate = DateTime.Parse(emailReportParams.EndDate);

            GenerateReportParams generateReportParams = new GenerateReportParams()
            {
                FileName = "report",
                StartDate = StartDate,
                EndDate = EndDate
            };

            _adminGenerateReportService.GenerateReport(generateReportParams);

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            
            message.From = new MailAddress("wlcmathplacement@gmail.com");
            try
            {
                message.To.Add(new MailAddress(emailReportParams.ToEmailAddress));
            }
            catch (Exception e)
            {
                return false;
            }

            message.Subject = "Student Report";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "";
            
            try
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@"..\..\PlacementTestReports\"+generateReportParams.FileName+".csv");
                message.Attachments.Add(attachment);
            }
            catch(Exception e)
            {
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
