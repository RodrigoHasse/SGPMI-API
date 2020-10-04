﻿using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Motivos
{
    public class MotivoInputModel : InputBasico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}