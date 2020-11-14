using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Relatorios
{
    public class cabecalhoRel
    {
        public string razaosocial { get; set; }
        public string fone { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string UF { get; set; }
        public string cep { get; set; }
    }

    public class dataRel
    {
        public string subTitulo { get; set; }
        public Object dados { get; set; }
    }

    public class RelatorioOutput
    {
        public cabecalhoRel cabecalho { get; set; }
        public string titulo { get; set; }
        public string[] colunas { get; set; }
        public dataRel[] data { get; set; }
        public decimal total { get; set; }
    }
}
