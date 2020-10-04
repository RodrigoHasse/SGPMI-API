using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.SharedContext.Models
{
    public class ErroSistemaHelper
    {
        public static AppErrorHelper retornarErroDetalhado(Exception e = null, List<string> listaNotificacoes = null)
        {
            var appErrorHelper = new AppErrorHelper();

            if (e != null) { 
                appErrorHelper.mensagem = e.Message;
                if(e.InnerException != null)
                    appErrorHelper.detalheMsg = e.InnerException.Message;
                appErrorHelper.detalheMsgTecnico = e.GetBaseException().ToString();
            }

            if (listaNotificacoes != null)
                appErrorHelper.mensagem = appErrorHelper.mensagem + " * " + string.Join(Environment.NewLine + " * ", listaNotificacoes.ToArray());


            return appErrorHelper; 
        }        
    }
}
