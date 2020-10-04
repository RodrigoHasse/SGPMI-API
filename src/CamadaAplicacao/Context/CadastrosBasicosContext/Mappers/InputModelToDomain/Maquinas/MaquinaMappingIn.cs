using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.InputModelToDomain.Maquinas
{
    public static class MaquinaMappingIn
    {
        public static void MaquinaMap(this CadastrosInputModelToDomainMappingProfile profile){
            profile.CreateMap<MaquinaInputModel, Maquina>();
        }
    }
}
