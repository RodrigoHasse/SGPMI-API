using CamadaCore.Context.CadastrosBasicoContext.Models.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.InputModelToDomain.Paradas
{
    public static class ParadaMappingIn
    {
        public static void ParadaMap(this CadastrosInputModelToDomainMappingProfile profile){
            profile.CreateMap<ParadaInputModel, Parada>();
        }
    }
}
