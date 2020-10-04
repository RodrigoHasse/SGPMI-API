using AutoMapper;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Maquinas;
using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Maquinas;
using MediatR;
using CamadaCoreCamadaCore.Context.SharedContext.Notificacoes;
using System;
using System.Threading;
using CamadaCore.Context.SharedContext.Helpers;
using System.Collections.Generic;

namespace CamadaCore.Context.CadastrosBasicoContext.Servicos.Maquinas
{
    public class ServicoMaquina : ServicoBasico<Maquina>, IServicoMaquina
    {
        private readonly IRepositorioMaquina _repositorioMaquina;
        private readonly IRepositorioMaquinaLeitura _repositorioLeituraMaquina;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ServicoMaquina(IRepositorioMaquina repositorioMaquina, IRepositorioMaquinaLeitura repositorioLeituraMaquina, 
            INotificacao notificacao, IMapper mapper, ILogger<ServicoMaquina> logger, IMediator mediator)
            : base(repositorioMaquina, notificacao, logger)
        {
            _repositorioMaquina = repositorioMaquina;
            _repositorioLeituraMaquina = repositorioLeituraMaquina;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AlterarStatusMaquina(Maquina maquina)
        {
            await SalvarAsync(maquina);
            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                await _mediator.Publish(new PushNotification
                {
                    app_id = "056f6456-136c-4238-80c6-33f8fe521bcc",
                    included_segments = "All",
                    data = "bar",
                    subtitle = "Aviso",
                    headings = "Aviso",
                    contents = maquina.Nome + (maquina.Ligada ? " foi ligada" : " foi desligada")
                }, cancellationToken) ;

                SGPMIHub _signalR = new SGPMIHub();

                List<Maquina> maquinas = new List<Maquina>();
                await _signalR.AtualizarMaquinasApp();
            }
            catch (Exception ex)
            {
                _notificacao.Adicionar(ex.Message);
            }
        }

        public override async Task ValidarAsync(Maquina maquina)
        {
            var maquinaValidacao = new MaquinaValidacao(maquina);

            foreach (var notificacao in maquinaValidacao.Contract.Notifications)
                _notificacao.Adicionar(notificacao.Message);
        }      
    }
}
