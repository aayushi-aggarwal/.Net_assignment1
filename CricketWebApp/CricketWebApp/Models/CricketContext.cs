using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CricketWebApp.Models
{
    public partial class CricketContext : DbContext
    {
        public CricketContext()
        {
        }

        public CricketContext(DbContextOptions<CricketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Stadium> Stadium { get; set; }

        // Unable to generate entity type for table 'dbo.Table_1'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Cricket;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId)
                    .HasColumnName("Country_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Continent)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("Country_code")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasColumnName("Country_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.Property(e => e.MatchId)
                    .HasColumnName("Match_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateTime)
                    .HasColumnName("Date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.StadiumId).HasColumnName("Stadium_id");

                entity.Property(e => e.WasMatchPlayed).HasColumnName("Was_Match_Played");

                entity.HasOne(d => d.Stadium)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.StadiumId)
                    .HasConstraintName("FK__Matches__Stadium__6C190EBB");

                entity.HasOne(d => d.TeamANavigation)
                    .WithMany(p => p.MatchesTeamANavigation)
                    .HasForeignKey(d => d.TeamA)
                    .HasConstraintName("FK__Matches__TeamA__6D0D32F4");

                entity.HasOne(d => d.TeamBNavigation)
                    .WithMany(p => p.MatchesTeamBNavigation)
                    .HasForeignKey(d => d.TeamB)
                    .HasConstraintName("FK__Matches__TeamB__6E01572D");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId)
                    .HasColumnName("Player_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PlayerAge).HasColumnName("Player_age");

                entity.Property(e => e.PlayerCountryid).HasColumnName("Player_countryid");

                entity.Property(e => e.PlayerName)
                    .HasColumnName("Player_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.PlayerCountry)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.PlayerCountryid)
                    .HasConstraintName("FK__Player__Player_c__628FA481");
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.Property(e => e.StadiumId)
                    .HasColumnName("Stadium_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NoOfMatchesAllowed).HasColumnName("No_of_matches_allowed");

                entity.Property(e => e.StadiumCount).HasColumnName("Stadium_count");

                entity.Property(e => e.StadiumName)
                    .HasColumnName("Stadium_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
