﻿using Entities.Models.Mortgage;
using Entities.Models.User;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Mortgage;

namespace ServiceLayer.Email
{
    public class EmailService : IEmailService
    {
        public void SendMortgageOfferEmail(string userEmail, Guid mortgageGuid)
        {
            // Get smtp Credentials from appsettings.json
            var senderEmail = Environment.GetEnvironmentVariable("SMTP_USERNAME");
            SmtpClient smtpClient = new(Environment.GetEnvironmentVariable("SMTP_SERVER"), 25)
            {
                Credentials = new NetworkCredential(Environment.GetEnvironmentVariable(senderEmail), Environment.GetEnvironmentVariable("SMTP_PASSWORD")),

                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            MailMessage mail = new()
            {
                From = new MailAddress(senderEmail),
                Body = $"Your mortgage offer is ready: www.example.com​/api​/Mortgage​/offer​/{mortgageGuid}."
            };
            mail.To.Add(new MailAddress(userEmail));

            smtpClient.Send(mail);
        }
    }
}
