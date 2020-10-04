using AutoMapper;
using CamadaAplicacao.Context.ConfiguracoesBasicosContext.Mappers.InputModelToDomain.Usuarios;

namespace CamadaAplicacao.Context.ConfiguracoesContext.Mappers
{
    public sealed class ConfiguracoesInputModelToDomainMappingProfile : Profile
    {
        public ConfiguracoesInputModelToDomainMappingProfile()
        {
            this.UsuarioMap();
        }
    }
}
