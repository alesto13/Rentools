using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rentools.Models
{
    public partial class RentoolsContext : DbContext
    {
        public RentoolsContext()
        {
        }

        public RentoolsContext(DbContextOptions<RentoolsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AjouterFavori> AjouterFavori { get; set; }
        public virtual DbSet<Annonce> Annonce { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<CategorieAnnonce> CategorieAnnonce { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<Membre> Membre { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<PeriodeLocation> PeriodeLocation { get; set; }
        public virtual DbSet<Plainte> Plainte { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=MyDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AjouterFavori>(entity =>
            {
                entity.HasKey(e => new { e.MembreidMembre, e.AnnonceidAnnonce })
                    .HasName("PK__AjouterF__3FF26A172A88561E");

                entity.Property(e => e.DateAjouter)
                    .HasColumnName("dateAjouter")
                    .HasColumnType("date");

                entity.HasOne(d => d.AnnonceidAnnonceNavigation)
                    .WithMany(p => p.AjouterFavori)
                    .HasForeignKey(d => d.AnnonceidAnnonce)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjouterFavori_Annonce");

                entity.HasOne(d => d.MembreidMembreNavigation)
                    .WithMany(p => p.AjouterFavori)
                    .HasForeignKey(d => d.MembreidMembre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AjouterFavori_Membre");
            });

            modelBuilder.Entity<Annonce>(entity =>
            {
                entity.HasKey(e => e.IdAnnonce)
                    .HasName("PK__Annonce__F217B71553FF019C");

                entity.Property(e => e.IdAnnonce).HasColumnName("idAnnonce");

                entity.Property(e => e.Emplacement)
                    .IsRequired()
                    .HasColumnName("emplacement")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.MembreidMembreNavigation)
                    .WithMany(p => p.Annonce)
                    .HasForeignKey(d => d.MembreidMembre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Annonce_Membre");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCategorie)
                    .HasName("PK__Categori__8A3D24086E88DB6E");

                entity.Property(e => e.IdCategorie).HasColumnName("idCategorie");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategorieAnnonce>(entity =>
            {
                entity.HasKey(e => new { e.CategorieidCategorie, e.AnnonceidAnnonce })
                    .HasName("PK__Categori__A15506761740B537");

                entity.ToTable("Categorie_Annonce");

                entity.HasOne(d => d.AnnonceidAnnonceNavigation)
                    .WithMany(p => p.CategorieAnnonce)
                    .HasForeignKey(d => d.AnnonceidAnnonce)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categorie_Annonce_Annonce");

                entity.HasOne(d => d.CategorieidCategorieNavigation)
                    .WithMany(p => p.CategorieAnnonce)
                    .HasForeignKey(d => d.CategorieidCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categorie_Annonce_Categorie");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasKey(e => new { e.AnnonceidAnnonce, e.PeriodeLocationidPeriode })
                    .HasName("PK__Detail__E29F3D4E214923F4");

                entity.Property(e => e.Prix).HasColumnName("prix");

                entity.HasOne(d => d.AnnonceidAnnonceNavigation)
                    .WithMany(p => p.Detail)
                    .HasForeignKey(d => d.AnnonceidAnnonce)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_Annonce");

                entity.HasOne(d => d.PeriodeLocationidPeriodeNavigation)
                    .WithMany(p => p.Detail)
                    .HasForeignKey(d => d.PeriodeLocationidPeriode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_PeriodeLocation");
            });

            modelBuilder.Entity<Membre>(entity =>
            {
                entity.HasKey(e => e.IdMembre)
                    .HasName("PK__Membre__7399C5D78D3E3528");

                entity.Property(e => e.IdMembre).HasColumnName("idMembre");

                entity.Property(e => e.Adresse)
                    .HasColumnName("adresse")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EstActive).HasColumnName("estActive");

                entity.Property(e => e.MotDePasse)
                    .IsRequired()
                    .HasColumnName("motDePasse")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone).HasColumnName("telephone");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.IdMessage)
                    .HasName("PK__Message__8D0E911DBDA5E552");

                entity.Property(e => e.IdMessage).HasColumnName("idMessage");

                entity.Property(e => e.DateContact)
                    .HasColumnName("dateContact")
                    .HasColumnType("date");

                entity.Property(e => e.DetailMessage)
                    .IsRequired()
                    .HasColumnName("detailMessage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MembreidMembreEnvoyerNavigation)
                    .WithMany(p => p.MessageMembreidMembreEnvoyerNavigation)
                    .HasForeignKey(d => d.MembreidMembreEnvoyer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_MembreEnvoyer");

                entity.HasOne(d => d.MembreidMembreRecevoirNavigation)
                    .WithMany(p => p.MessageMembreidMembreRecevoirNavigation)
                    .HasForeignKey(d => d.MembreidMembreRecevoir)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_MembreRecevoir");
            });

            modelBuilder.Entity<PeriodeLocation>(entity =>
            {
                entity.HasKey(e => e.IdPeriode)
                    .HasName("PK__PeriodeL__90A7D3CE14DB0CB5");

                entity.Property(e => e.IdPeriode).HasColumnName("idPeriode");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Duree).HasColumnName("duree");
            });

            modelBuilder.Entity<Plainte>(entity =>
            {
                entity.HasKey(e => new { e.MembreidMembre, e.AnnonceidAnnonce })
                    .HasName("PK__Plainte__3FF26A1767F699F7");

                entity.Property(e => e.DatePlainte)
                    .HasColumnName("datePlainte")
                    .HasColumnType("date");

                entity.Property(e => e.DetailPlainte)
                    .IsRequired()
                    .HasColumnName("detailPlainte")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnnonceidAnnonceNavigation)
                    .WithMany(p => p.Plainte)
                    .HasForeignKey(d => d.AnnonceidAnnonce)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plainte_Annonce");

                entity.HasOne(d => d.MembreidMembreNavigation)
                    .WithMany(p => p.Plainte)
                    .HasForeignKey(d => d.MembreidMembre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plainte_Membre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
