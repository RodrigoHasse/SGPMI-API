using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.ConfiguracoesContext.ViewModels.Inputs.Usuarios
{
    public class UsuarioInputModel : InputBasico
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }        
        public bool Ativo { get; set; }
        public bool Logado { get; set; }
        public string Email { get; set; }
        public DateTime UltimoLogin { get; set; }
    }
}
