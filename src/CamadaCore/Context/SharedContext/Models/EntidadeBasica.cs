using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.SharedContext.Models
{
    public abstract class EntidadeBasica
    {
        public EntidadeBasica()
        {
            //TimeZoneInfo Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Brazil/East");            
            //this.DataCriacao = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Standard_Time);
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            this.DataCriacao = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local,
                                                            easternZone);
            //this.DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
