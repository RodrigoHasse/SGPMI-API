using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.SharedContext.Helpers
{
    public class RetornoRelatorioHelper
    {
        public static RelatorioOutput montarRetornoRelatorio(String titulo, String[] colunas, dataRel[] dados, decimal total)
        {
            //TODO - BUSCAR CABECALHO
            var cab = new cabecalhoRel { razaosocial = "Empresa teste", endereco = "teste rua", bairro = "teste bairro", cep = "95200-000", fone = "3232-3232", UF = "RS" };            

            var retorno = new RelatorioOutput
            {
                cabecalho = cab,
                titulo = titulo,
                colunas = colunas,
                data = dados,
                total = total
            };

            return retorno;
        }
    }
}
