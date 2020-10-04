using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.SharedContext.Filtros
{
    public abstract class FiltroBasico
    {
        public int Pagina { get; set; }
        public int PorPagina { get; set; }
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
    }
}
