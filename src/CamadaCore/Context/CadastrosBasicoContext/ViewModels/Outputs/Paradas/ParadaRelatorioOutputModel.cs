using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas
{
    public class ParadaRelatorioOutputModel
    {
        public string MaquinaNome { get; set; }
        public double? TempoParada { get; set; }
        public string MotivoNome { get; set; }
        public string UsuarioNome { get; set; }
        public decimal? PercentualTempoParada { get; set; }
    }
}
