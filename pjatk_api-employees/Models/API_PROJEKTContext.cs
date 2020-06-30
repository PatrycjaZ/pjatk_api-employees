using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pjatk_api_employees.Models
{
    public partial class API_PROJEKTContext : DbContext
    {
        public API_PROJEKTContext()
        {
        }

        public API_PROJEKTContext(DbContextOptions<API_PROJEKTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Projekt> Projekt { get; set; }
        public virtual DbSet<Spotkanie> Spotkanie { get; set; }
        public virtual DbSet<UdzialWSpotkaniu> UdzialWSpotkaniu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q7C7E9V\\DB00;Initial Catalog=API_PROJEKT;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.Idpracownik)
                    .HasName("PRACOWNIK_pk");

                entity.ToTable("PRACOWNIK");

                entity.Property(e => e.Idpracownik).HasColumnName("IDPRACOWNIK");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("IMIE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasColumnName("MIASTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("NAZWISKO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NrTel)
                    .HasColumnName("NR_TEL")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.RokUr).HasColumnName("ROK_UR");

                entity.Property(e => e.Stanowisko)
                    .IsRequired()
                    .HasColumnName("STANOWISKO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TablicaInfo)
                    .HasColumnName("TABLICA_INFO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.HasKey(e => e.Idprojekt)
                    .HasName("PROJEKT_pk");

                entity.ToTable("PROJEKT");

                entity.Property(e => e.Idprojekt).HasColumnName("IDPROJEKT");

                entity.Property(e => e.Deadline)
                    .HasColumnName("DEADLINE")
                    .HasColumnType("date");

                entity.Property(e => e.Opis)
                    .HasColumnName("OPIS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Priorytet).HasColumnName("PRIORYTET");

                entity.Property(e => e.Projekt1)
                    .IsRequired()
                    .HasColumnName("PROJEKT")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Spotkanie>(entity =>
            {
                entity.HasKey(e => e.Idspotkanie)
                    .HasName("SPOTKANIE_pk");

                entity.ToTable("SPOTKANIE");

                entity.Property(e => e.Idspotkanie).HasColumnName("IDSPOTKANIE");

                entity.Property(e => e.Cel)
                    .IsRequired()
                    .HasColumnName("CEL")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DataSpotkania)
                    .HasColumnName("DATA_SPOTKANIA")
                    .HasColumnType("date");

                entity.Property(e => e.GodzRozp).HasColumnName("GODZ_ROZP");

                entity.Property(e => e.GodzZak).HasColumnName("GODZ_ZAK");

                entity.Property(e => e.Opis)
                    .HasColumnName("OPIS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjektIdprojekt).HasColumnName("PROJEKT_IDPROJEKT");

                entity.Property(e => e.Spotkanie1)
                    .IsRequired()
                    .HasColumnName("SPOTKANIE")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProjektIdprojektNavigation)
                    .WithMany(p => p.Spotkanie)
                    .HasForeignKey(d => d.ProjektIdprojekt)
                    .HasConstraintName("SPOTKANIE_PROJEKT");
            });

            modelBuilder.Entity<UdzialWSpotkaniu>(entity =>
            {
                entity.HasKey(e => new { e.SpotkanieIdspotkanie, e.PracownikIdpracownik })
                    .HasName("UDZIAL_W_SPOTKANIU_pk");

                entity.ToTable("UDZIAL_W_SPOTKANIU");

                entity.Property(e => e.SpotkanieIdspotkanie).HasColumnName("SPOTKANIE_IDSPOTKANIE");

                entity.Property(e => e.PracownikIdpracownik).HasColumnName("PRACOWNIK_IDPRACOWNIK");

                entity.Property(e => e.MiejsceSpotkania)
                    .IsRequired()
                    .HasColumnName("MIEJSCE_SPOTKANIA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.PracownikIdpracownikNavigation)
                    .WithMany(p => p.UdzialWSpotkaniu)
                    .HasForeignKey(d => d.PracownikIdpracownik)
                    .HasConstraintName("UDZIAL_W_SPOTKANIU_PRACOWNIK");

                entity.HasOne(d => d.SpotkanieIdspotkanieNavigation)
                    .WithMany(p => p.UdzialWSpotkaniu)
                    .HasForeignKey(d => d.SpotkanieIdspotkanie)
                    .HasConstraintName("UDZIAL_W_SPOTKANIU_SPOTKANIE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
