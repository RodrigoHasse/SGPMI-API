using CamadaAplicacao.Context.ConfiguracoesContext.Mappers;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios;

namespace CamadaAplicacao.Context.ConfiguracoesBasicosContext.Mappers.DomainToInputModel.Usuarios
{
    public static class UsuarioMappingOut
    {
        public static void UsuarioMap(this ConfiguracoesDomainToInputModelMappingProfile profile)
        {
            profile.CreateMap<Usuario, UsuarioOutputModel>();
        }
    }
}
