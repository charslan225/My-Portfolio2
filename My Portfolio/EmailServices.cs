using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace My_Portfolio
{
    public class EmailServices
    {
        private readonly IConfiguration _config;


public EmailServices(IConfiguration config)
{
_config = config;
}


public void Send(string name, string email, string message)
{
var smtp = new SmtpClient(_config["EmailSettings:Host"])
{
Port = int.Parse(_config["EmailSettings:Port"]),
Credentials = new NetworkCredential(
_config["EmailSettings:From"],
_config["EmailSettings:Password"]),
EnableSsl = true
};


var mail = new MailMessage
{
From = new MailAddress(_config["EmailSettings:From"], "Portfolio Contact"),
Subject = "New Portfolio Message",
Body = $"Name: {name}\nEmail: {email}\n\nMessage:\n{message}"
};


mail.To.Add(_config["EmailSettings:From"]);
smtp.Send(mail);
}
    }
}