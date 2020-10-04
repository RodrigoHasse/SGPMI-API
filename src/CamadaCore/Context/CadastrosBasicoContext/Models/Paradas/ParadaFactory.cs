using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.Models.Paradas
{
    public partial class Parada
    {
        public static Parada Criar(
            int id 
            ) =>
            new Parada()
            {
                Id = id
            };
    }
}
