using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.CategoriaMotivo;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.DomainToInputModel.CategoriaMotivos
{
    public static class CategoriaMotivoMappingOut
    {
        public static void MotivoMap(this CadastrosDomainToInputModelMappingProfile profile)
        {
            profile.CreateMap<CategoriaMotivo, CategoriaMotivoOutputModel>();
        }
    }
}
