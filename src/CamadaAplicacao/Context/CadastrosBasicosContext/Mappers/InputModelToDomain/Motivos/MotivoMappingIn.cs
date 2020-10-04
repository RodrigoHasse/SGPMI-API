using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Motivos;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.InputModelToDomain.Motivos
{
    public static class MotivoMappingIn
    {
        public static void MotivoMap(this CadastrosInputModelToDomainMappingProfile profile){
            profile.CreateMap<MotivoInputModel, Motivo>();
        }
    }
}
