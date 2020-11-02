using FluentValidator.Validation;
using CamadaCore.Context.SharedContext.Models;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using System.Collections.Generic;
using System;

namespace CamadaCore.Context.CadastrosBasicoContext.Models.Paradas
{
    public partial class Parada : EntidadeBasica
    {
        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int MaquinaId { get; set; }
        public virtual Maquina Maquina { get; set; }
        public int? MotivoId { get; set; }
        public virtual Motivo Motivo {get;set;}
        public DateTime? DataFimParada { get; set; }
        public DateTime? DataInicioParada { get; set; }
        public TimeSpan? TotalParada { get; set; }
        public double? TempoParada { get; set; }
    }
      
    public class ParadaValidacao : IContract
    {
        public ValidationContract Contract { get; }

        public ParadaValidacao(Parada Parada)
        {
            Contract = new ValidationContract();
            Contract
                .Requires();
                //.IsNotNullOrEmpty(Parada., "Nome", "Informe o Nome da Parada!");            
        }
    }
}
