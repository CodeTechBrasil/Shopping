using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace Common
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private MailJetSettings _mailJetSettings { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string body)
        {
            return Execute(email, subject, body);
        }
        //Pega as informações do arquivo [appsettings.json]

        public async Task Execute(string email, string subject, string body)
        {
            _mailJetSettings = _configuration.GetSection("MailJet").Get<MailJetSettings>();

            MailjetClient client = new MailjetClient(_mailJetSettings.ApiKey, _mailJetSettings.SecretKey)
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
                         new JObject
                         {
                          {
                            "From",
                            new JObject
                            {
                                {"Email", "meuemail@protonmail.com"},
                                {"Name", "NOME DO USUARIO"}
                            }
                          },
                          {
                           "To",
                           new JArray {
                            new JObject {
                             {
                              "Email",
                              email
                             }, {
                              "Name",
                              "NOME DE ENVIO"
                             }
                            }
                           }
                          }, {
                           "Subject",
                           subject
                          }, {
                           "HTMLPart",
                           body
                          }
                         }
                                 });
            await client.PostAsync(request);
        }
    }
}
