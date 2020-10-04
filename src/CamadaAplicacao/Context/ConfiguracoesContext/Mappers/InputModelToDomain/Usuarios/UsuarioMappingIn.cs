using CamadaAplicacao.Context.ConfiguracoesContext.Mappers;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Inputs.Usuarios;

namespace CamadaAplicacao.Context.ConfiguracoesBasicosContext.Mappers.InputModelToDomain.Usuarios
{
    public static class UsuarioMappingIn
    {
        public static void UsuarioMap(this ConfiguracoesInputModelToDomainMappingProfile profile){
            profile.CreateMap<UsuarioInputModel, Usuario>();
        }
    }
}
