using CamadaCore.Context.SharedContext.Models;
using Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Interfaces.Entity
{
    public interface IRepositorio<T> where T: EntidadeBasica
    {
        Task<Option<T>> RetornarPorIdAsync(int id);
        Task<Option<T>> RetornarPorExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<Option<IQueryable<T>>> RetornarVariosAsync(Expression<Func<T, bool>> predicate = null);
        void Salvar(T entidade);
        void Excluir(T entidade);
    }
}
