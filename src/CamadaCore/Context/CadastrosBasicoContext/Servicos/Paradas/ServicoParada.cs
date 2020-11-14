using AutoMapper;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using CamadaCore.Context.CadastrosBasicoContext.Models.Paradas;
using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Paradas;

namespace CamadaCore.Context.CadastrosBasicoContext.Servicos.Paradas
{
    public class ServicoParada : ServicoBasico<Parada>, IServicoParada
    {
        private readonly IRepositorioParada _repositorioParada;
        private readonly IRepositorioParadaLeitura _repositorioLeituraParada;
        private readonly IMapper _mapper;

        public ServicoParada(IRepositorioParada repositorioParada, IRepositorioParadaLeitura repositorioLeituraParada, 
            INotificacao notificacao, IMapper mapper, ILogger<ServicoParada> logger)
            : base(repositorioParada, notificacao, logger)
        {
            _repositorioParada = repositorioParada;
            _repositorioLeituraParada = repositorioLeituraParada;
            _mapper = mapper;
        }                

        public override async Task ValidarAsync(Parada cidade)
        {
            var ParadaValidacao = new ParadaValidacao(cidade);            

            foreach (var notificacao in ParadaValidacao.Contract.Notifications)
                _notificacao.Adicionar(notificacao.Message);
        }
        

    }
}
