using CamadaCore.Context.SharedContext.Filtros;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.ConfiguracoesContext.Filtros.Usuarios
{
    public class FiltroUsuarios: FiltroBasico
    {
        public FiltroLista Organizacoes { get; set; }
    }
}
