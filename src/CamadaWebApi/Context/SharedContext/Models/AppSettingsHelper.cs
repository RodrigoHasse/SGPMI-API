using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.SharedContext.Models
{
    public class AppSettingsHelper
    {
        public string Secret { get; set; }
        public string ConnectionString { get; set; }
    }
}
