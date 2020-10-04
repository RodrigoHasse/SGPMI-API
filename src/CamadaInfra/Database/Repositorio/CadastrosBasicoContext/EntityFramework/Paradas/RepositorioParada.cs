using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Paradas;
using CamadaInfra.Database.Context;
using CamadaInfra.Database.Repositorio.SharedContext.EntityFramework;

namespace CamadaInfra.Database.Repositorio.CadastrosBasicoContext.EntityFramework.Paradas
{
    public class RepositorioParada : RepositorioBasico<Parada>, IRepositorioParada
    {
        public RepositorioParada(ContextoPrincipal contextoPrincipal) : base(contextoPrincipal){}
    }
}
