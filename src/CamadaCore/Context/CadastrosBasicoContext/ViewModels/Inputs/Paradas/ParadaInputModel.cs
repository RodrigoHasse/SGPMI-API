using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using System;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas
{
    public class ParadaInputModel : InputBasico
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int MaquinaId { get; set; }
        public int? MotivoId { get; set; }
        public DateTime? DataFimParada { get; set; }
        public DateTime? DataInicioParada { get; set; }
        public TimeSpan? TotalParada { get; set; }
        public double? TempoParada { get; set; }
    }
}