using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using CamadaInfra.Database.Repositorio.SharedContext.Dapper;
using Microsoft.Extensions.Configuration;
using Optional;
using System.Collections.Generic;
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
            sb.AppendLine(Filtrar(filtros, false));
            return sb.ToString();
        }

        private string BuscarParadas(FiltroParadasInputModel filtro)
        {
            var sb = new StringBuilder();
            sb.Clear();
            sb.AppendLine("SELECT par.Id, par.UsuarioId, par.MaquinaId, par.MotivoId, par.DataCriacao, usu.Nome as UsuarioNome, maq.Nome as MaquinaNome, mot.Nome as MotivoNome ");
            sb.AppendLine(" from Paradas par");
            sb.AppendLine(RetornarJoins());
            sb.AppendLine(Filtrar(filtro));
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

        private string Filtrar(FiltroParadasInputModel filtro, bool ordenar = true)
        {
            var sb = new StringBuilder();
            bool ordenarPorCampo = false;

            if (!string.IsNullOrWhiteSpace(filtro.Valor))
            {
                if ((!string.IsNullOrEmpty(filtro.Campo)) && (!string.IsNullOrEmpty(filtro.Valor)))
                {
                    if(filtro.Tipo == "string")
                        sb.AppendLine($" WHERE {filtro.Campo} LIKE '%{filtro.Valor}%'");
                    if (filtro.Tipo == "int")
                        sb.AppendLine($" WHERE {filtro.Campo} = {filtro.Valor}");

                    ordenarPorCampo = true;
                }
            }

            if (ordenar)
            {
                if (ordenarPorCampo)
                    sb.AppendLine($" ORDER BY {filtro.Campo}");
                else
                    sb.AppendLine(" ORDER BY par.Id");
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
