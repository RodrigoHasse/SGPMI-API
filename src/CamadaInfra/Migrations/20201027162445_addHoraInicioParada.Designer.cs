﻿// <auto-generated />
using System;
using CamadaInfra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CamadaInfra.Migrations
{
    [DbContext(typeof(ContextoPrincipal))]
    [Migration("20201027162445_addHoraInicioParada")]
    partial class addHoraInicioParada
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas.Maquina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<bool>("Ligada");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Maquinas");
                });

            modelBuilder.Entity("CamadaCore.Context.CadastrosBasicoContext.Models.Motivos.Motivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Motivos");
                });

            modelBuilder.Entity("CamadaCore.Context.CadastrosBasicoContext.Models.Paradas.Parada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime?>("DataFimParada");

                    b.Property<DateTime?>("DataInicioParada");

                    b.Property<int>("MaquinaId");

                    b.Property<int?>("MotivoId");

                    b.Property<TimeSpan?>("TotalParada");

                    b.Property<int?>("UsuarioId");

                    b.Property<string>("teste");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaId");

                    b.HasIndex("MotivoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Paradas");
                });

            modelBuilder.Entity("CamadaCore.Context.ConfiguracoesContext.Models.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Email");

                    b.Property<bool>("Logado");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("UltimoLogin");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CamadaCore.Context.CadastrosBasicoContext.Models.Paradas.Parada", b =>
                {
                    b.HasOne("CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas.Maquina", "Maquina")
                        .WithMany("Paradas")
                        .HasForeignKey("MaquinaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CamadaCore.Context.CadastrosBasicoContext.Models.Motivos.Motivo", "Motivo")
                        .WithMany()
                        .HasForeignKey("MotivoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CamadaCore.Context.ConfiguracoesContext.Models.Usuarios.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
