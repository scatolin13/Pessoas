﻿using Microsoft.EntityFrameworkCore;
using Pessoas.Models;

#nullable disable

namespace Pessoas.Repository.DataStore
{
    public partial class ContextPessoa : DbContext
    {
        public ContextPessoa()
        {
        }

        public ContextPessoa(DbContextOptions<ContextPessoa> options)
            : base(options)
        {
        }

        public virtual DbSet<Deficiencium> Deficiencia { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }
        public virtual DbSet<GrauInstrucao> GrauInstrucaos { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<PessoaDeficiencium> PessoaDeficiencia { get; set; }
        public virtual DbSet<RacaCor> RacaCors { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=M2RGNTK0001;Initial Catalog=db_pessoas;Trusted_Connection=True;Connection Timeout=10800");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Deficiencium>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detalhamento)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.ToTable("EstadoCivil");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GrauInstrucao>(entity =>
            {
                entity.ToTable("GrauInstrucao");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Cpfsimples)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPFSimples");

                entity.Property(e => e.DataExclusao).HasColumnType("datetime");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMae)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomePai)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomeSocial)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoCivil)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.EstadoCivilId)
                    .HasConstraintName("FK_Pessoa_EstadoCivil");

                entity.HasOne(d => d.GrauInstrucao)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.GrauInstrucaoId)
                    .HasConstraintName("FK_Pessoa_GrauInstrucao");

                entity.HasOne(d => d.RacaCor)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.RacaCorId)
                    .HasConstraintName("FK_Pessoa_RacaCor");

                entity.HasOne(d => d.Sexo)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.SexoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Sexo");
            });

            modelBuilder.Entity<PessoaDeficiencium>(entity =>
            {
                entity.HasOne(d => d.Deficiencia)
                    .WithMany(p => p.PessoaDeficiencia)
                    .HasForeignKey(d => d.DeficienciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PessoaDeficiencia_Deficiencia");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.PessoaDeficiencia)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PessoaDeficiencia_Pessoa");
            });

            modelBuilder.Entity<RacaCor>(entity =>
            {
                entity.ToTable("RacaCor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.ToTable("Sexo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}