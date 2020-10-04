using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Inputs.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios;
using CamadaInfra.Database.Repositorio.SharedContext.Dapper;
using Microsoft.Extensions.Configuration;
using Optional;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Repositorio.CadastrosBasicoContext.Dapper.Usuarios
{
    public class RepositorioUsuarioDapper : RepositorioBaseDapper<UsuarioOutputModel, FiltroUsuariosInputModel>, IRepositorioUsuarioLeitura
    {
        public RepositorioUsuarioDapper(IConfiguration config) : base(config)
        {
        }

        public override async Task<Option<IEnumerable<UsuarioOutputModel>>> ListarAsync(FiltroUsuariosInputModel filtro)
        {
            List<UsuarioOutputModel> retorno = new List<UsuarioOutputModel>();
            //retorno.TotalRegitros = await RetornarInteiroAsync(BuscarQuantidadeCidades(filtros));            

            return await RetornarTodosAsync(BuscarUsuarios());
        }

        private string BuscarQuantidadeUsuarios(FiltroUsuariosInputModel filtros)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT Count(usu.Id) FROM Usuarios usu");
            sb.AppendLine(RetornarJoins());
            sb.AppendLine(Filtrar(filtros, false));

            return sb.ToString();
        }

        private string BuscarUsuarios()
        {
            //int avanco = ((filtro.PorPagina * filtro.Pagina) - filtro.PorPagina);

            var sb = new StringBuilder();
            sb.Clear();
            sb.AppendLine("SELECT");
            sb.AppendLine(" usu.Id,");
            sb.AppendLine(" usu.Nome,");
            sb.AppendLine(" usu.Login,");
            sb.AppendLine(" usu.Email");
            sb.AppendLine(" from Usuarios usu");
            sb.AppendLine(RetornarJoins());

            // sb.AppendLine(Filtrar(filtro));

            //sb.AppendLine($" OFFSET {avanco} ROWS ");
            //sb.AppendLine($" FETCH NEXT {filtro.PorPagina} ROWS ONLY");
            return sb.ToString();
        }

        private string RetornarJoins()
        {
            //var sb = new StringBuilder();
            //sb.AppendLine(" Inner join estados est on cid.EstadoId = est.id");
            //sb.AppendLine(" Inner join paises pai on est.PaisId = pai.id");
            return "";
        }

        private string Filtrar(FiltroUsuariosInputModel filtro, bool ordenar = true)
        {
            var sb = new StringBuilder();
            bool ordenarPorCampo = false;

            if (!string.IsNullOrWhiteSpace(filtro.Valor))
            {
                if ((!string.IsNullOrEmpty(filtro.Campo)) && (!string.IsNullOrEmpty(filtro.Valor)))
                {
                    sb.AppendLine($" WHERE {filtro.Campo} LIKE '%{filtro.Valor}%'");
                    ordenarPorCampo = true;
                }
            }

            if (ordenar)
            {
                if (ordenarPorCampo)
                    sb.AppendLine($" ORDER BY {filtro.Campo}");
                else
                    sb.AppendLine(" ORDER BY usu.Nome");
            }

            return sb.ToString();
        }

        private string RetornarIds(List<int> ids)
        {
            string valor = "";
            if (ids.Count > 0)
            {
                valor = "";
                int contador = 1;

                foreach (var item in ids)
                {
                    if (contador == 1)
                        valor = valor + item.ToString();
                    else
                        valor = valor + "," + item.ToString();
                    contador++;
                }
            }
            return valor;
        }
    }
}
