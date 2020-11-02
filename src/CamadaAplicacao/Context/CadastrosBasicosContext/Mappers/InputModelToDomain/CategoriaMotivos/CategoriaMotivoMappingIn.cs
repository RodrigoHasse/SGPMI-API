using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.CategoriaMotivo;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Mappers.InputModelToDomain.CategoriaMotivos
{
    public static class CategoriaMotivoMappingIn
    {
        public static void CategoriaMotivoMap(this CadastrosInputModelToDomainMappingProfile profile){
            profile.CreateMap<CategoriaMotivoInputModel, CategoriaMotivo>();
        }
    }
}
