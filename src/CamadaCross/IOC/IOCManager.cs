using CamadaInfra.Database.Context;
using CamadaCore.Context.SharedContext.Interfaces.Trasacoes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.SharedContext.Validacoes;
using System.Linq;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Maquinas;
using CamadaInfra.Database.Repositorio.CadastrosBasicoContext.Dapper.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Servicos.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Maquinas;
using CamadaInfra.Database.Repositorio.CadastrosBasicoContext.EntityFramework.Maquinas;
using CamadaInfra.Database.Repositorio.ConfiguracoesContext.EntityFrameWork.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.Interfaces.Entity.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.Servicos.Usuarios;
using CamadaInfra.Database.Repositorio.CadastrosBasicoContext.EntityFramework.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Motivos;
using CamadaInfra.Database.Repositorio.CadastrosBasicoContext.Dapper.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Servicos.Motivos;
using CamadaAplicacao.Context.CadastrosBasicosContext.Servicos.Maquinas;
using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Maquinas;
using CamadaAplicacao.Context.ConfiguracoesContext.Servicos.Usuarios;
using CamadaAplicacao.Context.ConfiguracoesContext.Interfaces.Usuarios;
using CamadaAplicacao.Context.CadastrosBasicosContext.Servicos.Motivos;
using CamadaInfra.Database.Repositorio.CadastrosBasicoContext.Dapper.Usuarios;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Usuarios;
using CamadaInfra.Database.Repositorio.CadastrosBasicoContext.EntityFramework.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Paradas;
using CamadaInfra.Database.Repositorio.CadastrosBasicoContext.Dapper.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.Servicos.Paradas;
using CamadaAplicacao.Context.CadastrosBasicosContext.Servicos.Paradas;
using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Paradas;

namespace CamadaCross.IOC
{
    public static class IOCManager
    {
        public static void Register(string connectionString, IServiceCollection services)
        {
            services.AddDbContext<ContextoPrincipal>(options => options.UseSqlServer(connectionString).UseLazyLoadingProxies());
            //services.AddDbContext<ContextoPrincipal>();
            services.AddScoped<ITransacao, Transacao>();

            var coreAssembly = System.Reflection.Assembly.GetAssembly(typeof(ServicoMaquina));            
            var infraAssembly = System.Reflection.Assembly.GetAssembly(typeof(RepositorioMaquina));

            // REPOSITORIO ENTITYFRAMEWORK
            services.AddScoped<IRepositorioMaquina, RepositorioMaquina>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IRepositorioMotivo, RepositorioMotivo>();
            services.AddScoped<IRepositorioParada, RepositorioParada>();

            // REPOSITORIO DAPPER
            // services.AddScoped(typeof(IRepositorioBaseLeitura<OutputBasico, FiltroBasicoInput>), typeof(RepositorioBaseDapper<OutputBasico, FiltroBasicoInput>));
            services.AddScoped<IRepositorioMaquinaLeitura, RepositorioMaquinaDapper>();
            services.AddScoped<IRepositorioMotivoLeitura, RepositorioMotivoDapper>();
            services.AddScoped<IRepositorioUsuarioLeitura, RepositorioUsuarioDapper>();
            services.AddScoped<IRepositorioParadaLeitura, RepositorioParadaDapper>();

            services.AddScoped<INotificacao, Notificacao>();


            // SERVICOS                       
            services.AddScoped<IServicoMaquina, ServicoMaquina>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
            services.AddScoped<IServicoMotivo, ServicoMotivo>();
            services.AddScoped<IServicoParada, ServicoParada>();

            services.AddScoped(typeof(ServicoMaquina));
            services.AddScoped(typeof(ServicoMotivo));
            services.AddScoped(typeof(ServicoUsuario));
            services.AddScoped(typeof(ServicoParada));


            //APLICACAO SERVICO
            services.AddScoped<IServicoAplicacaoMaquina, ServicoAplicacaoMaquina>();
            services.AddScoped<IServicoAplicacaoUsuario, ServicoAplicacaoUsuario>();
            services.AddScoped<IServicoAplicacaoMotivo, ServicoAplicacaoMotivo>();
            services.AddScoped<IServicoAplicacaoParada, ServicoAplicacaoParada>();

            // SERVICOS                       
            var classesServico = coreAssembly
                    .GetTypes()
                    .Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(ServicoBasico<>)))
                    .ToArray();
            foreach (var c in classesServico)
                services.AddScoped(c);
        }
    }
}
