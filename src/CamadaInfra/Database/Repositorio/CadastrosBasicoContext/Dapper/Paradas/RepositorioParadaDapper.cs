using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using CamadaInfra.Database.Repositorio.SharedContext.Dapper;
using Microsoft.Extensions.Configuration;
using Optional;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Repositorio.CadastrosBasicoContext.Dapper.Paradas
{   
    public class RepositorioParadaDapper : RepositorioBaseDapper<ParadaOutputModel, FiltroParadasInputModel>, IRepositorioParadaLeitura
    {
        public RepositorioParadaDapper(IConfiguration config) : base(config)
        {
        }

        public override async Task<Option<IEnumerable<ParadaOutputModel>>> ListarAsync(FiltroParadasInputModel filtro)
        {
            List<ParadaOutputModel> retorno = new List<ParadaOutputModel>();
            //retorno.TotalRegitros = await RetornarInteiroAsync(BuscarQuantidadeCidades(filtros));            

            return await RetornarTodosAsync(BuscarParadas(filtro));
        }

        private string BuscarQuantidadeParadas(FiltroParadasInputModel filtros)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT Count(par.Id) FROM Paradas par");
            sb.AppendLine(RetornarJoins());
            sb.AppendLine(Filtrar(filtros));
            return sb.ToString();
        }

        private string BuscarParadas(FiltroParadasInputModel filtro)
        {
            var sb = new StringBuilder();
            sb.Clear();
            sb.AppendLine("SELECT par.Id, par.UsuarioId, par.MaquinaId, par.MotivoId, par.DataCriacao, usu.Nome as UsuarioNome, maq.Nome as MaquinaNome, mot.Nome as MotivoNome, par.DataFimParada, par.TotalParada, par.DataInicioParada, par.TempoParada ");
            sb.AppendLine(" from Paradas par");
            sb.AppendLine(RetornarJoins());
            sb.AppendLine(Filtrar(filtro));
            sb.AppendLine(" ORDER BY par.DataInicioParada desc");
            return sb.ToString();
        }

        private string RetornarJoins()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" Inner join Maquinas maq on par.MaquinaId = maq.id");
            sb.AppendLine(" Left join Usuarios usu on par.UsuarioId = usu.id");
            sb.AppendLine(" Left join Motivos mot on par.MotivoId = mot.id");
            return sb.ToString();
        }

        private string Filtrar(FiltroParadasInputModel filtro)
        {
            var sb = new StringBuilder();

            if (filtro.DataInicial != null)
            {
                string isoFormatDateString = filtro.DataInicial.ToString("yyyy-MM-ddT00:00:00.fffzzz");
                sb.AppendLine($" WHERE par.dataInicioParada >= '{isoFormatDateString}'");
            }

            if (filtro.DataFinal != null)
            {
                string isoFormatDateString = filtro.DataFinal.ToString("yyyy-MM-ddT23:59:59.fffzzz");
                sb.AppendLine($" AND par.dataInicioParada <= '{isoFormatDateString}'");
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

        public async Task<decimal> RetornarTotalTempoParada(FiltroParadasInputModel filtro)
        {
            var sb = new StringBuilder();
            sb.Clear();
            sb.AppendLine("SELECT coalesce(sum(par.TempoParada), 0) as Total");
            sb.AppendLine(" from Paradas par");
            sb.AppendLine(RetornarJoins());
            sb.AppendLine(Filtrar(filtro));
            //return sb.ToString();

            return await RetornarDecimalAsync(sb.ToString());
        }
    }
}
