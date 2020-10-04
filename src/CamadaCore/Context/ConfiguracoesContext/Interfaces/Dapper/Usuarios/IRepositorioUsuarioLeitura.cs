using CamadaCore.Context.ConfiguracoesContext.ViewModels.Inputs.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios;
using CamadaCore.Context.SharedContext.Interfaces.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Usuarios
{
    public interface IRepositorioUsuarioLeitura : IRepositorioBaseLeitura<UsuarioOutputModel, FiltroUsuariosInputModel>
    {

    }
}
