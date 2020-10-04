using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Motivos;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.DomainToInputModel.Motivos
{
    public static class MotivoMappingOut
    {
        public static void MotivoMap(this CadastrosDomainToInputModelMappingProfile profile)
        {
            profile.CreateMap<Motivo, MotivoOutputModel>();
        }
    }
}
