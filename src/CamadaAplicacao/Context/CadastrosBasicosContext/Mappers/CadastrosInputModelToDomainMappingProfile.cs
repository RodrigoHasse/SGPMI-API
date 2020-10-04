using AutoMapper;
using CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.InputModelToDomain.Maquinas;
using CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.InputModelToDomain.Motivos;
using CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.InputModelToDomain.Paradas;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers
{
    public sealed class CadastrosInputModelToDomainMappingProfile : Profile
    {
        public CadastrosInputModelToDomainMappingProfile()
        {
            this.MaquinaMap();
            this.MotivoMap();
            this.ParadaMap();
        }
    }
}
