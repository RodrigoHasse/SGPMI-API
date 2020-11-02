using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using System;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas
{
    public class ParadaOutputModel: OutputBasico
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public int MaquinaId { get; set; }
        public string MaquinaNome { get; set; }
        public int? MotivoId { get; set; }
        public string MotivoNome { get; set; }
        public DateTime? DataFimParada { get; set; }
        public DateTime? DataInicioParada { get; set; }
        public TimeSpan? TotalParada { get; set; }
        public double? TempoParada { get; set; }
    }    
}
