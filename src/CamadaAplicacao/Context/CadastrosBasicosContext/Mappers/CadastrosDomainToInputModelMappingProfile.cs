using AutoMapper;
using CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.DomainToInputModel.Maquinas;
using CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.DomainToInputModel.Motivos;
using CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.DomainToInputModel.Paradas;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers
{
    public sealed class CadastrosDomainToInputModelMappingProfile: Profile
    {
        public CadastrosDomainToInputModelMappingProfile()
        {
            this.MaquinaMap();
            this.MotivoMap();
            this.ParadaMap();
        }
    }
}
