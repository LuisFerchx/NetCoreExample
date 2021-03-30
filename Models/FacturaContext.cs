using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NetCoreExample.Models
{
    public partial class FacturaContext : DbContext
    {
        public FacturaContext()
        {
        }

        public FacturaContext(DbContextOptions<FacturaContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<Item> Items { get; set; }
        
        public virtual DbSet<Persona> Personas { get; set; }
        
        public virtual DbSet<VenTransaccioncabecera> VenTransaccioncabeceras { get; set; }
        public virtual DbSet<VenTransacciondetalle> VenTransacciondetalles { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseNpgsql("User ID=u1riijcrjpmkvxwffvui;Password=RZ9siJy1Xk2EusD0Mffd;Host=bvjwrdnlvq6xz9rznv9q-postgresql.services.clever-cloud.com;Port=5432;Database=bvjwrdnlvq6xz9rznv9q;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasPostgresExtension("autoinc")
                .HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("file_fdw")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("insert_username")
                .HasPostgresExtension("intagg")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("isn")
                .HasPostgresExtension("lo")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("moddatetime")
                .HasPostgresExtension("pageinspect")
                .HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_freespacemap")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_tiger_geocoder")
                .HasPostgresExtension("refint")
                .HasPostgresExtension("seg")
                .HasPostgresExtension("sslinfo")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("tcn")
                .HasPostgresExtension("timetravel")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2")
                .HasAnnotation("Relational:Collation", "en_GB.utf8");

            

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.PerId)
                    .HasName("persona_pk");
            });

            

            modelBuilder.Entity<VenTransaccioncabecera>(entity =>
            {
                entity.HasKey(e => e.CabId)
                    .HasName("ven_transaccioncabecera_pk");

                entity.HasComment("venta cabecera");

                entity.Property(e => e.PerId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Per)
                    .WithMany(p => p.VenTransaccioncabeceras)
                    .HasForeignKey(d => d.PerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ven_transaccioncabecera_fk");
            });

            modelBuilder.Entity<VenTransacciondetalle>(entity =>
            {
                entity.HasKey(e => e.DetId)
                    .HasName("ven_transacciondetalle_pk");

                entity.HasComment("venta detalle");

                entity.Property(e => e.CabId).ValueGeneratedOnAdd();

                entity.Property(e => e.DetEstado).HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.IteId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Cab)
                    .WithMany(p => p.VenTransacciondetalles)
                    .HasForeignKey(d => d.CabId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ven_transacciondetalle_fk");

                entity.HasOne(d => d.Ite)
                    .WithMany(p => p.VenTransacciondetalles)
                    .HasForeignKey(d => d.IteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_ventransdet_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
