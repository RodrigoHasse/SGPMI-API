using CamadaCore.Context.SharedContext.Interfaces.Dapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Optional;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Repositorio.SharedContext.Dapper
{
    public abstract class RepositorioBaseDapper<T,In> : IRepositorioBaseLeitura<T, In> 
        where T : class 
        where In : class
    {
        //string connection = "data source=(localdb)\\mssqllocaldb;initial catalog=webapidomper;integrated security=true;multipleactiveresultsets=true";
        private readonly IConfiguration _configuration;

        public RepositorioBaseDapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual async Task<Option<IEnumerable<T>>> ListarAsync(In filtros)
        {
            return Option.None<IEnumerable<T>>();
        } 

        public async Task<Option<IEnumerable<T>>> RetornarTodosAsync(string instrucaoSQL)
        {
            return await RetornarTodosWrapper(connection =>
                {
                    return connection.QueryAsync<T>(instrucaoSQL);
                });

            //var conexao = _configuration.GetSection("AppSettings").GetSection("ConnectionString").Value;

            //using (var db = new SqlConnection(conexao))
            //{
            //    var consulta =  await db.QueryAsync<T>(instrucaoSQL);
            //    return consulta == null ? Option.None<IEnumerable<T>>() : Option.Some<IEnumerable<T>>(consulta);
            //}
        }

        public async Task<int> RetornarInteiroAsync(string instrucaoSQL)
        {
            var conexao = ConexaoBanco();

            using (var db = new SqlConnection(conexao))
            {
                var consulta = await db.QueryAsync<int>(instrucaoSQL);
                return consulta.FirstOrDefault();
            }
        }

        public async Task<decimal> RetornarDecimalAsync(string instrucaoSQL)
        {
            var conexao = ConexaoBanco();

            using (var db = new SqlConnection(conexao))
            {
                var consulta = await db.QueryAsync<decimal>(instrucaoSQL);
                return consulta.FirstOrDefault();
            }
        }

        private async Task<Option<IEnumerable<T>>> RetornarTodosWrapper(Func<IDbConnection, Task<IEnumerable<T>>> acao)
        {
            var conexao = ConexaoBanco();

            using (var db = new SqlConnection(conexao))
            {
                await db.OpenAsync();
                var retorno = await acao.Invoke(db);
                return retorno == null ? Option.None<IEnumerable<T>>() : Option.Some<IEnumerable<T>>(retorno);
                //var consulta = await db.QueryAsync<T>(instrucaoSQL);
                //return consulta == null ? Option.None<IEnumerable<T>>() : Option.Some<IEnumerable<T>>(consulta);
            }
        }

        private string ConexaoBanco()
        {
            return _configuration.GetSection("AppSettings").GetSection("ConnectionString").Value;
        }
    }
}