using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Optional;
using CamadaInfra.Database.Context;
using CamadaCore.Context.SharedContext.Interfaces.Entity;
using CamadaCore.Context.SharedContext.Models;

namespace CamadaInfra.Database.Repositorio.SharedContext.EntityFramework
{
    public abstract class RepositorioBasico<T> : IRepositorio<T> where T : EntidadeBasica
    {
        protected readonly ContextoPrincipal _contexto;
        protected readonly DbSet<T> dbSet;

        public RepositorioBasico(ContextoPrincipal contextoPrincipal)
        {
            _contexto = contextoPrincipal;
            dbSet = contextoPrincipal.Set<T>();
        }

        public virtual async Task<Option<T>> RetornarPorIdAsync(int id)
        {
            var consulta = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return consulta == null ? Option.None<T>() : Option.Some<T>(consulta);
        }

        public virtual async Task<Option<T>> RetornarPorExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            var consulta = await dbSet.FirstOrDefaultAsync(predicate);
            return consulta == null ? Option.None<T>() : Option.Some<T>(consulta);
        }

        public virtual async Task<Option<IQueryable<T>>> RetornarVariosAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query;
            if (predicate != null)
                query = dbSet.Where(predicate);
            else
                query = dbSet;

            var list = await query.ToListAsync();
            var consulta = list.AsQueryable();
            return consulta == null ? Option.None< IQueryable<T>>() : Option.Some< IQueryable<T>>(consulta);
        }

        public virtual void Salvar(T entidade)
        {
            if (entidade.Id == 0)
            {
                _contexto.Add(entidade);
            } else
            {
                _contexto.Attach(entidade);
                _contexto.Entry(entidade).State = EntityState.Modified;
            }
        }

        public virtual void Excluir(T entidade)
        {
            _contexto.Remove(entidade);
        }

        #region Wrapper

        protected async Task<Option<IQueryable<T>>> RetornarColecaoWrapper(Func<Task<IQueryable<T>>> acao)
        {
            var retorno = await acao.Invoke();  
            return retorno == null ? Option.None<IQueryable<T>>() : Option.Some<IQueryable<T>>(retorno);
        }

        protected async Task<Option<T>> RetornarUnicoWrapper(Func<Task<T>> acao, int codigo)
        {
            var retorno = await acao.Invoke();
            return retorno == null ? Option.None<T>() : Option.Some<T>(retorno);
        }

        #endregion
    }
}
