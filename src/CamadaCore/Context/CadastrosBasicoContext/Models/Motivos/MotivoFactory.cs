using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.Models.Motivos
{
    public partial class Motivo
    {
        public static Motivo Criar(
            int id, 
            string nome
            ) =>
            new Motivo()
            {
                Id = id,
                Nome = nome                
            };
    }
}
