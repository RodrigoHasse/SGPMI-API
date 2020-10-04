using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Interfaces.Trasacoes
{
    public interface ITransacao
    {
        Task BeginTransactionAsync();
        void Commit();
        void Rollback();
        Task SaveChangesAsync();
    }
}
