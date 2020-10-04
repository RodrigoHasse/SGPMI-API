using CamadaCore.Context.CadastrosBasicoContext.Models.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.DomainToInputModel.Paradas
{
    public static class ParadaMappingOut
    {
        public static void ParadaMap(this CadastrosDomainToInputModelMappingProfile profile)
        {
            profile.CreateMap<Parada, ParadaOutputModel>();
        }
    }
}
