using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CamadaInfra.Database.Context
{
    public class ContextoPrincipal : DbContext
    {
        public ContextoPrincipal()
        {
        }

        public ContextoPrincipal(DbContextOptions<ContextoPrincipal> options):base(options)
        {
           
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var tipos = this.GetType().Assembly.GetTypes()
                .Where(x => x.Name.EndsWith("Configuration") &&
                !x.IsAbstract &&
                !x.IsInterface).ToArray();
            foreach(var t in tipos)
            {
                dynamic classe = Activator.CreateInstance(t);
                modelBuilder.ApplyConfiguration(classe);
            }
        }
    }
}
