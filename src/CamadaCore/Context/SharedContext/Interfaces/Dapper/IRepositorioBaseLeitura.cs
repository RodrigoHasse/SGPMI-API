using Optional;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Interfaces.Dapper
{
    public interface IRepositorioBaseLeitura<T, In>
        where T : class
        where In : class
    {
        Task<Option<IEnumerable<T>>> ListarAsync(In filtros);
        Task<Option<IEnumerable<T>>> RetornarTodosAsync(string instrucaoSQL);
        Task<int> RetornarInteiroAsync(string instrucaoSQL);
    }
}
