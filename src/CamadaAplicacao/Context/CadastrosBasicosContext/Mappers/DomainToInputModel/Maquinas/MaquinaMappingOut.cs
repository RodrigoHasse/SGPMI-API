using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.DomainToInputModel.Maquinas
{
    public static class MotivoMappingOut
    {
        public static void MaquinaMap(this CadastrosDomainToInputModelMappingProfile profile)
        {
            profile.CreateMap<Maquina, MaquinaOutputModel>();
        }
    }
}
