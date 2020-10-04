using AutoMapper;
using CamadaAplicacao.Context.CadastrosBasicosContext.Mappers;
using System;

namespace CamadaAplicacao.Context.SharedContext.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static MapperConfiguration RegisterMappings(IServiceProvider serviceProvider)
        {
            var config = new MapperConfiguration(cfg => {
                
                cfg.AddProfile(new CadastrosInputModelToDomainMappingProfile());
                cfg.AddProfile(new CadastrosDomainToInputModelMappingProfile());
            });

            config.AssertConfigurationIsValid();
            return config;
        }
    }
}
