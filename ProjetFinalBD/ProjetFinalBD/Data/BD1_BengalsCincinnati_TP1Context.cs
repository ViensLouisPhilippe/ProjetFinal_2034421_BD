using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetFinalBD.Models;

namespace ProjetFinalBD.Data
{
    public partial class BD1_BengalsCincinnati_TP1Context : DbContext
    {
        public BD1_BengalsCincinnati_TP1Context()
        {
        }

        public BD1_BengalsCincinnati_TP1Context(DbContextOptions<BD1_BengalsCincinnati_TP1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Defense> Defenses { get; set; } = null!;
        public virtual DbSet<Passing> Passings { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Receiving> Receivings { get; set; } = null!;
        public virtual DbSet<Rushing> Rushings { get; set; } = null!;
        public virtual DbSet<Stat> Stats { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<VwInfoJoueurEtContract> VwInfoJoueurEtContracts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BD1_BengalsCincinnati_TP1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasOne(d => d.Player)
                    .WithOne(p => p.Contract)
                    .HasForeignKey<Contract>(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_PlayerID");
            });

            modelBuilder.Entity<Defense>(entity =>
            {
                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.Defenses)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Defense_StatID");
            });

            modelBuilder.Entity<Passing>(entity =>
            {
                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.Passings)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passing_StatID");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_TeamID");
            });

            modelBuilder.Entity<Receiving>(entity =>
            {
                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.Receivings)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receiving_StatID");
            });

            modelBuilder.Entity<Rushing>(entity =>
            {
                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.Rushings)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rushing_StatID");
            });

            modelBuilder.Entity<Stat>(entity =>
            {
                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Stats)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stat_PlayerID");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.ExpectedDateReturn).HasDefaultValueSql("('Next Season')");

                entity.Property(e => e.ReasonUnavailability).HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_PlayerID");
            });

            modelBuilder.Entity<VwInfoJoueurEtContract>(entity =>
            {
                entity.ToView("vw_InfoJoueurEtContract", "Players");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
