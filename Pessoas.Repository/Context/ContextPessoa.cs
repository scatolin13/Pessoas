using FluntValidation.Notifications;
using Microsoft.EntityFrameworkCore;
using Pessoas.Models;

#nullable disable

namespace Pessoas.Repository.Context
{
    public partial class ContextPessoa
    {
        public virtual DbSet<Deficiencia> Deficiencia { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }
        public virtual DbSet<GrauInstrucao> GrauInstrucaos { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<RacaCor> RacaCors { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Deficiencia>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detalhamento)
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

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMae)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomePai)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeSocial)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipoInscricaoId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.EstadoCivil)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.EstadoCivilId)
                    .HasConstraintName("FK__Pessoa__EstadoCi__3F466844");

                entity.HasOne(d => d.GrauInstrucao)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.GrauInstrucaoId)
                    .HasConstraintName("FK__Pessoa__GrauInst__403A8C7D");

                entity.HasOne(d => d.RacaCor)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.RacaCorId)
                    .HasConstraintName("FK__Pessoa__RacaCorI__3E52440B");

                entity.HasOne(d => d.Sexo)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.SexoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pessoa__SexoId__3D5E1FD2");
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

                entity.Property(e => e.Id).ValueGeneratedNever();

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
