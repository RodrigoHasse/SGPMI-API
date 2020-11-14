using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Motivos;
using CamadaInfra.Database.Repositorio.SharedContext.Dapper;
using Microsoft.Extensions.Configuration;
using Optional;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Repositorio.CadastrosBasicoContext.Dapper.Motivos
{
    public class RepositorioMotivoDapper : RepositorioBaseDapper<MotivoOutputModel, FiltroMotivosInputModel>, IRepositorioMotivoLeitura
    {
        public RepositorioMotivoDapper(IConfiguration config) : base(config)
        {
        }

        public override async Task<Option<IEnumerable<MotivoOutputModel>>> ListarAsync(FiltroMotivosInputModel filtros)
        {
            List<MotivoOutputModel> retorno = new List<MotivoOutputModel>();
            //retorno.TotalRegitros = await RetornarInteiroAsync(BuscarQuantidadeCidades(filtros));            

            return await RetornarTodosAsync(BuscarMotivos());
        }

        private string BuscarQuantidadeMotivos(FiltroMotivosInputModel filtros)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT Count(mot.Id) FROM Motivos mot");
            sb.AppendLine(RetornarJoins());
            sb.AppendLine(Filtrar(filtros, false));

            return sb.ToString();
        }

        private string BuscarMotivos()
        {
            // int avanco = ((filtro.PorPagina * filtro.Pagina) - filtro.PorPagina);

            var sb = new StringBuilder();
            sb.Clear();
            sb.AppendLine("SELECT");
            sb.AppendLine(" mot.Id,");
            sb.AppendLine(" mot.Nome");
            sb.AppendLine(" from Motivos mot");
            sb.AppendLine(RetornarJoins());
            sb.AppendLine("Order by mot.Nome");
            //sb.AppendLine(Filtrar(filtro));

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

        private string Filtrar(FiltroMotivosInputModel filtro, bool ordenar = true)
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
                    sb.AppendLine(" ORDER BY mot.Nome");
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
