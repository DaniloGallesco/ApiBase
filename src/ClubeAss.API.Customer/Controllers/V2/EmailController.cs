using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace ClubeAss.API.Customer.Controllers.V2
{
    [ApiController]    
    [ApiVersion("2.0")]
    [Route("API/v{version:apiVersion}/[controller]")]    
    public class EmailController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("2.0")]
        public void Index()
        {
            var smtpClient = new SmtpClient("localhost")
            {
                Port = 1025,
                EnableSsl = false
            };

            var _mailMessage = new MailMessage()
            {
                Body = "Texto de corpo",
                From = new MailAddress("Teste@teste.com.br"),
                Subject = "Titulo"
            };
            _mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            _mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            _mailMessage.To.Add("teste@teste.com.br");

            smtpClient.Send(_mailMessage);
        }
    }
}