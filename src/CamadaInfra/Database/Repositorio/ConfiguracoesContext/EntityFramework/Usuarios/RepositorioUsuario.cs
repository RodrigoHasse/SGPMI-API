using CamadaInfra.Database.Repositorio.SharedContext.EntityFramework;
using CamadaInfra.Database.Context;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.Interfaces.Entity.Usuarios;

namespace CamadaInfra.Database.Repositorio.ConfiguracoesContext.EntityFrameWork.Usuarios
{
    public class RepositorioUsuario : RepositorioBasico<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ContextoPrincipal contextoPrincipal) : base(contextoPrincipal){}        
    }
}