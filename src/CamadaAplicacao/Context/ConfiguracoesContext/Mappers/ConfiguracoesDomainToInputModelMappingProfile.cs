using AutoMapper;
using CamadaAplicacao.Context.ConfiguracoesBasicosContext.Mappers.DomainToInputModel.Usuarios;

namespace CamadaAplicacao.Context.ConfiguracoesContext.Mappers
{
    public sealed class ConfiguracoesDomainToInputModelMappingProfile: Profile
    {
        public ConfiguracoesDomainToInputModelMappingProfile()
        {
            this.UsuarioMap();
        }
    }
}
