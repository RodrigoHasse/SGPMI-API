using FluentValidator.Validation;
using CamadaCore.Context.SharedContext.Models;

namespace CamadaCore.Context.CadastrosBasicoContext.Models.Motivos
{
    public partial class Motivo : EntidadeBasica
    {
        public string Nome { get; set; }
    }

    public class MotivoValidacao : IContract
    {
        public ValidationContract Contract { get; }

        public MotivoValidacao(Motivo motivo)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNullOrEmpty(motivo.Nome, "Nome", "Informe o Nome do Motivo!");            
        }
    }
}
