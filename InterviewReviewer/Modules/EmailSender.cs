using InterviewReviewer.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace InterviewReviewer.Modules
{
    internal class EmailSender : IModule
    {
        public string Name { get; set; } = "Email Sender";
        private readonly string _senderEmailAddress;
        private readonly string _senderEmailPassword;

        public EmailSender()
        {
            var directory = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .Build();

            _senderEmailAddress = config["senderEmailAddress"] ?? "";
            _senderEmailPassword = config["senderEmailPassword"] ?? "";
        }

        public string DescribeModule()
        {
            return "Enter an email address and this module will send an email there.\n";
        }

        public void Run()
        {
            Console.WriteLine("Uh oh, the stuff has hit the fan!\n\nEnter your name:\n");
            var recipientName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter your email address: ");
            var recipientEmail = Console.ReadLine() ?? "";

            SendEmail(recipientName, recipientEmail);
        }

        private void SendEmail(string recipientName, string recipientEmail)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.LocalDomain = "hotmail.com";
                    client.Connect("smtp.office365.com", 587, false);
                    client.Authenticate(_senderEmailAddress, _senderEmailPassword);
                    client.Send(CreateMessage(recipientName, recipientEmail));
                    client.Disconnect(true);
                }
                Console.WriteLine("Successfully sent an email to {0}, be sure to check your spam folder.", recipientEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bad news... There was a problem sending the email: {0}", ex.Message);
            }
        }

        private MimeMessage CreateMessage(string recipientName, string recipientEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Warren Zevon", "warren.zevon.lgam@hotmail.com"));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));
            message.Subject = "Re: The Stuff Has Hit the Fan";
            message.Body = new TextPart("plain")
            {
                Text = string.Format("Dear {0},\n\nIn reply to your recent request for help, we are sending Lawyers, Guns and Money. Good luck.\n\n--W.Z.", recipientName)
            };

            return message;
        }
    }
}