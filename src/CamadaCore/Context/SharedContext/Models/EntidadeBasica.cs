using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.SharedContext.Models
{
    public abstract class EntidadeBasica
    {
        public EntidadeBasica()
        {
            this.DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
