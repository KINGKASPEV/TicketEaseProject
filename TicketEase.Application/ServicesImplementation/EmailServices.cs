﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using TicketEase.Application.Interfaces.Services;
using TicketEase.Domain.Entities;

namespace TicketEase.Application.ServicesImplementation
{
    public class EmailServices : IEmailServices
    {

        private readonly EmailSettings emailSettings;
        public EmailServices(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }

        public async Task SendHtmlEmailAsync(MailRequest mailRequest)
        {
            var message = new MimeMessage
            {
                Sender = MailboxAddress.Parse(emailSettings.Email)
            };
            message.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            message.Subject = mailRequest.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = mailRequest.Body
            };

            byte[] fileBytes1;
            byte[] fileBytes2;

            if (System.IO.File.Exists("EmailAttachments/freedom.jpeg") && System.IO.File.Exists("EmailAttachments/lorem.jpeg"))
            {
                using (var ms1 = new MemoryStream())
                using (var file1 = new FileStream("EmailAttachments/freedom.jpeg", FileMode.Open, FileAccess.Read))
                {
                    file1.CopyTo(ms1);
                    fileBytes1 = ms1.ToArray();
                    builder.Attachments.Add("attachment1.jpeg", fileBytes1, ContentType.Parse("application/octet-stream"));
                }

                using (var ms2 = new MemoryStream())
                using (var file2 = new FileStream("EmailAttachments/lorem.jpeg", FileMode.Open, FileAccess.Read))
                {
                    file2.CopyTo(ms2);
                    fileBytes2 = ms2.ToArray();
                    builder.Attachments.Add("attachment2.jpeg", fileBytes2, ContentType.Parse("application/octet-stream"));
                }
            }

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {

                    //await client.ConnectAsync("smtp.your-email-provider.com", 587, false);
                    await client.ConnectAsync(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(emailSettings.Email, emailSettings.Password);
                    await client.SendAsync(message);

                }
                catch (Exception ex)
                {

                    throw new InvalidOperationException("Email sending failed.", ex);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}