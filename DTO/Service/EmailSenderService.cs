using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service
{
    public class EmailSenderService : IEmailSender, IDisposable
    {
        public MimeMessage _message { get; set; }
        public BodyBuilder _bodyBuilder { get; set; }
        public SmtpClient _client { get; set; }
        public EmailSenderService()
        {
            _message= new MimeMessage();
            _bodyBuilder= new BodyBuilder();
            _client= new SmtpClient();

            _client.Connect("smtp.gmail.com", 465, true);
            _client.Authenticate("dimomaks1@gmail.com", "erlyccmoderecjaa");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailboxAddress from = new MailboxAddress("TechnoShop", "dimomaks1@gmail.com");
            MailboxAddress to = new MailboxAddress(email, email);
            _message.From.Add(from);
            _message.To.Add(to);

            _message.Subject = subject;

            _bodyBuilder.HtmlBody = $@"
<h1>Привет!</h1>
<p>Для подтверждения почты нажмите сюда: {htmlMessage}</p>
";


            _message.Body = _bodyBuilder.ToMessageBody();
            return _client.SendAsync(_message);
        }
        public void Dispose()
        {
            _client.Disconnect(true);
            _client.Dispose();
        }

    }
}
