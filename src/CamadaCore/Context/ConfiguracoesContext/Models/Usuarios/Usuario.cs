using CamadaCore.Context.SharedContext.Models;
using System;
using System.Collections.Generic;

namespace CamadaCore.Context.ConfiguracoesContext.Models.Usuarios
{
    public class Usuario : EntidadeBasica
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool Logado { get; set; }
        public DateTime UltimoLogin { get; set; }
        public string Email { get; set; }
    }

    public class UsuarioRetorno
    {
        public int TotalRegitros { get; set; }
        public List<UsuarioRetornoLista> UsuarioRetornoListas { get; set; }
    }

    public class UsuarioRetornoLista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public int OrganizacaoId { get; set; }
        public string OrganizacaoNome { get; set; }
        public bool Ativo { get; set; }
    }
}
