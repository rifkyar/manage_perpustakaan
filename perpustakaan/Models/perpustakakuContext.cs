using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace perpustakaan.Models
{
    public partial class perpustakakuContext : DbContext
    {
        public perpustakakuContext()
        {
        }

        public perpustakakuContext(DbContextOptions<perpustakakuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbGenre> TbGenres { get; set; }
        public virtual DbSet<TbJeni> TbJenis { get; set; }
        public virtual DbSet<TbRak> TbRaks { get; set; }
        public virtual DbSet<TbTrBuku> TbTrBukus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7POTMS\\SQLEXPRESS;Initial Catalog=perpustakaku;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<TbGenre>(entity =>
            {
                entity.ToTable("tb_genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdJenis).HasColumnName("id_jenis");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdJenisNavigation)
                    .WithMany(p => p.TbGenres)
                    .HasForeignKey(d => d.IdJenis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_genre_tb_jenis");
            });

            modelBuilder.Entity<TbJeni>(entity =>
            {
                entity.ToTable("tb_jenis");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<TbRak>(entity =>
            {
                entity.ToTable("tb_rak");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<TbTrBuku>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tb_tr_buku");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Jenis).HasColumnName("jenis");

                entity.Property(e => e.JudulBuku)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("judul_buku");

                entity.Property(e => e.KodeBuku).HasColumnName("kode_buku");

                entity.Property(e => e.Rak).HasColumnName("rak");

                entity.Property(e => e.TahunBuku)
                    .HasColumnType("date")
                    .HasColumnName("tahun_buku");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
