using CamadaCore.Context.SharedContext.Models;
using FluentValidator.Validation;

namespace CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos
{
    public partial class CategoriaMotivo: EntidadeBasica
    {
        public string Nome { get; set; }
    }

    public class CategoriaMotivoValidacao : IContract
    {
        public ValidationContract Contract { get; }

        public CategoriaMotivoValidacao(CategoriaMotivo CategoriaMotivo)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNullOrEmpty(CategoriaMotivo.Nome, "Nome", "Informe o Nome da Categoria!");
        }
    }
}
