using AutoMapper;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Motivos;

namespace CamadaCore.Context.CadastrosBasicoContext.Servicos.Motivos
{
    public class ServicoMotivo : ServicoBasico<Motivo>, IServicoMotivo
    {
        private readonly IRepositorioMotivo _repositorioMotivo;
        private readonly IRepositorioMotivoLeitura _repositorioLeituraMotivo;
        private readonly IMapper _mapper;

        public ServicoMotivo(IRepositorioMotivo repositorioMotivo, IRepositorioMotivoLeitura repositorioLeituraMotivo, 
            INotificacao notificacao, IMapper mapper, ILogger<ServicoMotivo> logger)
            : base(repositorioMotivo, notificacao, logger)
        {
            _repositorioMotivo = repositorioMotivo;
            _repositorioLeituraMotivo = repositorioLeituraMotivo;
            _mapper = mapper;
        }                

        public override async Task ValidarAsync(Motivo motivo)
        {
            var motivoValidacao = new MotivoValidacao(motivo);            

            foreach (var notificacao in motivoValidacao.Contract.Notifications)
                _notificacao.Adicionar(notificacao.Message);
        }      
    }
}
