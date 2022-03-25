// do not delete bin/ and obj/ (NuGet package required to rebuild)

using System.Net.Mail;
using System.Net.Mime;

var smtpClient = new SmtpClient();
/* if credentials required:
SmtpClient smtpClient = new SmtpClient
{
    Credentials = new NeworkCredential("person@isp.whatever", "person's-password"),
    EnableSsl = true
}
*/
smtpClient.Host = "mailer.louisiana.edu";
smtpClient.Port = 25;

var mailMessage = new MailMessage();

mailMessage.Sender = new MailAddress("c00252259@louisiana.edu", "HRH");
mailMessage.From = new MailAddress("c00252259@louisiana.edu", "HRH");
mailMessage.To.Add(new MailAddress("fdd@louisiana.edu", "Grand Poobah"));
mailMessage.CC.Add(new MailAddress("fducrest@louisiana.edu", "Grandie"));
mailMessage.Subject = "Beethoven";

var message =
    "Born: Bonn\nBaptised: 17 December 1770\nDied: 26 March 1827 (aged 56) Vienna\nOccupation: composer and pianist\n";
mailMessage.Body = message;
mailMessage.IsBodyHtml = false;
mailMessage.Priority = MailPriority.Normal;

var image = new Attachment("../../../beethoven.jpg", MediaTypeNames.Image.Jpeg);
mailMessage.Attachments.Add(image);

smtpClient.Send(mailMessage);