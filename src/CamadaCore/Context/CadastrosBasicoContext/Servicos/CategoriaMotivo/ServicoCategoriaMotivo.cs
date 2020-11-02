using AutoMapper;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.CategoriaMotivo;

namespace CamadaCore.Context.CadastrosBasicoContext.Servicos.CategoriaMotivos
{
    public class ServicoCategoriaMotivo : ServicoBasico<CategoriaMotivo>, IServicoCategoriaMotivo
    {
        private readonly IRepositorioCategoriaMotivo _repositorioCategoriaMotivo;
        private readonly IRepositorioCategoriaMotivoLeitura _repositorioLeituraCategoriaMotivo;
        private readonly IMapper _mapper;

        public ServicoCategoriaMotivo(IRepositorioCategoriaMotivo repositorioCategoriaMotivo, IRepositorioCategoriaMotivoLeitura repositorioLeituraCategoriaMotivo, 
            INotificacao notificacao, IMapper mapper, ILogger<ServicoCategoriaMotivo> logger)
            : base(repositorioCategoriaMotivo, notificacao, logger)
        {
            _repositorioCategoriaMotivo = repositorioCategoriaMotivo;
            _repositorioLeituraCategoriaMotivo = repositorioLeituraCategoriaMotivo;
            _mapper = mapper;
        }                

        public override async Task ValidarAsync(CategoriaMotivo categoriaMotivo)
        {
            var categoriaMotivoValidacao = new CategoriaMotivoValidacao(categoriaMotivo);            

            foreach (var notificacao in categoriaMotivoValidacao.Contract.Notifications)
                _notificacao.Adicionar(notificacao.Message);
        }      
    }
}
