using CamadaCore.Context.SharedContext.Interfaces.Trasacoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Context
{
    public class Transacao : ITransacao
    {
        private readonly ContextoPrincipal _contexto;

        public Transacao(ContextoPrincipal contexto)
        {
            _contexto = contexto;
        }

        public async Task BeginTransactionAsync()
        {
            await _contexto.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
             _contexto.Database.CommitTransaction();
        }

        public void Rollback()
        {
             _contexto.Database.RollbackTransaction();
        }

        public async Task SaveChangesAsync()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}
