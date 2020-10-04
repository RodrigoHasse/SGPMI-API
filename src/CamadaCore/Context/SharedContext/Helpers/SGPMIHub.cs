using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Helpers
{
    public class SGPMIHub: Hub  
    {
        public async Task AtualizarMaquinasApp()
        {            
            await Clients.Others.SendAsync("AtualizarMaquinas", null);
        }        
    }
}
