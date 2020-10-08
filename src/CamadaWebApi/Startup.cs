using AutoMapper;
using CamadaAplicacao.Context.SharedContext.Mappers;
using CamadaCore.Context.SharedContext.Helpers;
using CamadaCoreCamadaCore.Context.SharedContext.Notificacoes;
using CamadaWebApi.Authorization;
using CamadaWebApi.Context.SharedContext.Models;
using ElmahCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
//using Swashbuckle.AspNetCore.Swagger;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CamadaWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettingsHelper>(appSettingsSection);

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddMediatR(typeof(PushNotification));

            services.AddSignalR(options =>
            {
                
                    options.EnableDetailedErrors = true;
            });

            var appSettings = appSettingsSection.Get<AppSettingsHelper>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiCustomAuthorizePolicy",
                    policy =>
                    {
                        policy.Requirements.Add(new ApiCustomAuthorizeRequirement());
                    });
            });
            services.AddScoped<IAuthorizationHandler, ApiCustomAuthorizeHandler>();

            CamadaCross.IOC.IOCManager.Register(appSettings.ConnectionString, services);

            services.AddSingleton<TokenManagerHelper>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("comum", new Info { Title = "Web Api", Version = "comum" });
            //    c.SwaggerDoc("configuracoes", new Info { Title = "Web Api", Version = "configuracoes" });
            //    c.SwaggerDoc("cadastros", new Info { Title = "Web Api", Version = "cadastros" });

            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);
            //});
            //services.AddSignalR(cfg => {
            //    cfg.EnableDetailedErrors = true;
            //})
            //    .AddMessagePackProtocol()
            //    .AddJsonProtocol(cfg => {
            //        cfg.PayloadSerializerSettings.ContractResolver = new DefaultContractResolver();
            //    });

            services.AddElmah(options => {
                options.Path = @"elmah";
                options.CheckPermissionAction = context => ((context.User.Identity.IsAuthenticated) &&
                                                           (context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "ADM"));
            });

            // ajusta mapster
            //    TypeAdapterConfig<Produto, ProdutoViewModel>
            //        .NewConfig()
            //        .Map(dest => dest.PrecoTotal, src => src.CalcularPrecoComposicao(1));

            //    TypeAdapterConfig<Produto, ProdutoListaViewModel>
            //        .NewConfig()
            //        .Map(dest => dest.PrecoTotal, src => src.CalcularPrecoComposicao(1));
            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //  app.UseExceptionHandler("/Home/Error");
            //}

            loggerFactory
                .AddConsole()
                .AddDebug();

            app.UseStaticFiles();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseAuthentication();

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/configuracoes/swagger.json", "WebApi - Configuracoes");
            //    c.SwaggerEndpoint("/swagger/comum/swagger.json", "WebApi - Comum");
            //    c.SwaggerEndpoint("/swagger/cadastros/swagger.json", "WebApi - Cadastros");
            //});

            app.UseElmah();

            app.UseSignalR(cfg =>
            {
                cfg.MapHub<SGPMIHub>("/WebHub");
            });
        }
    }
}
