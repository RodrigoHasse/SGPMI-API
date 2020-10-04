using System.Collections.Generic;

namespace CamadaCore.Context.SharedContext.Interfaces.Notificacoes
{
    public interface INotificacao
    {
        void Adicionar(string mensagem);
        bool IsValid();
        List<string> RetornarErros();
    }
}
