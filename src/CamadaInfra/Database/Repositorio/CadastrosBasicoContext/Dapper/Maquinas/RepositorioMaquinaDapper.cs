using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;
using CamadaInfra.Database.Repositorio.SharedContext.Dapper;
using Microsoft.Extensions.Configuration;
using Optional;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Repositorio.CadastrosBasicoContext.Dapper.Maquinas
{
    public class RepositorioMaquinaDapper : RepositorioBaseDapper<MaquinaOutputModel, FiltroMaquinasInputModel>, IRepositorioMaquinaLeitura
    {
        public RepositorioMaquinaDapper(IConfiguration config) : base(config)
        {

        }

        public override async Task<Option<IEnumerable<MaquinaOutputModel>>> ListarAsync(FiltroMaquinasInputModel filtro)
        {
                    //List<MaquinaOutputModel> retorno = new List<MaquinaOutputModel>();
            //retorno.TotalRegitros = await RetornarInteiroAsync(BuscarQuantidadeCidades(filtros));            

            return await RetornarTodosAsync(BuscarMaquinas());
        }

        private string BuscarQuantidadeMaquinas(FiltroMaquinasInputModel filtros)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT Count(maq.Id) FROM Maquinas maq");
            sb.AppendLine(RetornarJoins());
            sb.AppendLine(Filtrar(filtros, false));

            return sb.ToString();
        }

        private string BuscarMaquinas()
        {
            //int avanco = ((filtro.PorPagina * filtro.Pagina) - filtro.PorPagina);

            var sb = new StringBuilder();
            sb.Clear();
            sb.AppendLine("SELECT");
            sb.AppendLine(" maq.Id,");
            sb.AppendLine(" maq.Ligada,");
            sb.AppendLine(" maq.Nome");
            sb.AppendLine(" from Maquinas maq");
            
            //sb.AppendLine(RetornarJoins());

            //sb.AppendLine(Filtrar(filtro));

            //sb.AppendLine($" OFFSET {avanco} ROWS ");
            //sb.AppendLine($" FETCH NEXT {filtro.PorPagina} ROWS ONLY");
            return sb.ToString();
        }

        private string RetornarJoins()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" Inner join Paradas par on par.MaquinaId = maq.Id");
            return sb.ToString();
        }

        private string Filtrar(FiltroMaquinasInputModel filtro, bool ordenar = true)
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
                    sb.AppendLine(" ORDER BY maq.Nome");
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
