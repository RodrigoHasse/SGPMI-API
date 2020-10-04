using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.SharedContext.Enums
{
    public enum TipoPessoa
    {
        Fisica = 'F',
        Juridica = 'J'
    }

    public enum RegimeTributario
    {
        SimplesNacional = 1,
        SimplesNacionalEx = 2,
        LucroPresumido = 3,
        LucroReal = 4
    }

    public enum TipoDocumento
    {
        CPF = 1, 
        CNPJ = 2, 
        IE = 3, 
        IM = 4, 
        RG = 5,
        CNH = 6, 
        CTPS = 7
    }

    public enum TipoEndereco
    {
        Principal = 1,
        Cobranca = 2,
        Entrega = 3
    }

    public enum TipoPermissao
    {
        Acesso = 1,
        Inserir = 2,
        Alterar = 3,
        Excluir = 4,
        Relatorio = 5 
    }
}
