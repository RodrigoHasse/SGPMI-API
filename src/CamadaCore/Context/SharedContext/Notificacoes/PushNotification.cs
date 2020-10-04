using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CamadaCoreCamadaCore.Context.SharedContext.Notificacoes
{
    public class PushNotification : INotification
    {
        public string app_id { get; set; }
        public string  included_segments { get; set; }
        public string data { get; set; }
        public string subtitle { get; set; }
        public string headings { get; set; }
        public string contents { get; set; }
    }
}
