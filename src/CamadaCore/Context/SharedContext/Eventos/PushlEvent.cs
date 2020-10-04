using CamadaCoreCamadaCore.Context.SharedContext.Notificacoes;
using MediatR;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Eventos
{
    public class PushlEvent : INotificationHandler<PushNotification>
    {
        public Task Handle(PushNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return EnviarPush(notification);
            });
        }

        private async Task EnviarPush(PushNotification notification)
        {
            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic MmQ2MDM2YmItMWM3OC00NmU5LWFjOTQtOWQ4NDFmNTlhNDRi ");
            
            byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                        + $"\"app_id\": \"{notification.app_id}\","
                                        + "\"contents\": {\"en\": \""+notification.contents+"\"},"
                                        + "\"headings\": {\"en\": \"" + notification.headings + "\"},"
                                        + "\"included_segments\": [\"All\"]}");            

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }
            System.Diagnostics.Debug.WriteLine(responseContent);
        }
    }
}