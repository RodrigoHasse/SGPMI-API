using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos
{
    public partial class CategoriaMotivo
    {
        public static CategoriaMotivo Criar(
            int id, 
            string nome
            ) =>
            new CategoriaMotivo()
            {
                Id = id,
                Nome = nome                
            };
    }
}
