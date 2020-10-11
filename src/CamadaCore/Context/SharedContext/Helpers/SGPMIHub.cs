using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Helpers
{
    public class SGPMIHub: Hub  
    {
        public SGPMIHub()
        {

        }
        public async Task AtualizarMaquinasApp()
        {
            if(Clients!= null)
            {
                await this.Clients.Others.SendAsync("AtualizarMaquinas");
            }
            
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
