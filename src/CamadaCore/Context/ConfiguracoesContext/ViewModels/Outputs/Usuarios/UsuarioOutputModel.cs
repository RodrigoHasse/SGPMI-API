using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios
{
    public class UsuarioOutputModel : OutputBasico
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool Logado { get; set; }
        public string Email { get; set; }
        public DateTime UltimoLogin { get; set; }
    }
}
