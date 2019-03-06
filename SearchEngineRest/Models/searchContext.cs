using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SearchEngineRest.Models
{
    public partial class SearchContext : DbContext
    {
        public SearchContext()
        {
        }

        public SearchContext(DbContextOptions<SearchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Term> Term { get; set; }
        public virtual DbSet<TermDoc> TermDoc { get; set; }

        public virtual DbSet<LogItem> LogItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=search;Username=search;Password=search123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<LogItem>(entity =>
            {
                entity.ToTable("logitem");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.timestamp).HasColumnName("timestamp");

                entity.Property(e => e.message)
                    .HasColumnName("message")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("document");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.ToTable("term");

                entity.HasIndex(e => e.Value)
                    .HasName("value_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TermDoc>(entity =>
            {
                entity.HasKey(e => new { e.Docid, e.Termid, e.Position })
                    .HasName("term_doc_id_idx");

                entity.ToTable("term_doc");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Termid).HasColumnName("termid");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.TermDoc)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_docid");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.TermDoc)
                    .HasForeignKey(d => d.Termid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_termid");
            });
        }
    }
}
