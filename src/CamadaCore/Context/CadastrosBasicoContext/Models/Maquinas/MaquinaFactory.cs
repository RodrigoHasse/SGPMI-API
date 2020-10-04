using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas
{
    public partial class Maquina
    {
        public static Maquina Criar(
            int id, 
            string nome,
            bool ligada
            ) =>
            new Maquina()
            {
                Id = id,
                Nome = nome,                
                Ligada = ligada
            };
    }
}
