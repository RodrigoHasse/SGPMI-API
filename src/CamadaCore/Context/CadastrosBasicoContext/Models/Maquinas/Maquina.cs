using FluentValidator.Validation;
using CamadaCore.Context.SharedContext.Models;

namespace CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas
{
    public partial class Maquina : EntidadeBasica
    {
        public string Nome { get; private set; }
        public bool Ligada { get; set; }
    }

    public class MaquinaValidacao : IContract
    {
        public ValidationContract Contract { get; }

        public MaquinaValidacao(Maquina Maquina)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNullOrEmpty(Maquina.Nome, "Nome", "Informe o Nome da Maquina!");            
        }
    }
}