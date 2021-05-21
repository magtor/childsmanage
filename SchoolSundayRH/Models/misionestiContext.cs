using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSundayRH.Models
{
    public partial class misionestiContext : DbContext
    {
        public misionestiContext()
        {
        }

        public misionestiContext(DbContextOptions<misionestiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Childs> Childs { get; set; }
        public virtual DbSet<Listarcabecera> Listarcabecera { get; set; }
        public virtual DbSet<Listardetalle> Listardetalle { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Maestros> Maestros { get; set; }
        public virtual DbSet<Padres> Padres { get; set; }
        public virtual DbSet<Padreshijos> Padreshijos { get; set; }
        public virtual DbSet<Porceptrimestre> Porceptrimestre { get; set; }
        public virtual DbSet<Tallazapatos> Tallazapatos { get; set; }
        public virtual DbSet<Trimestreyear> Trimestreyear { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
         //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=misionesti;uid=sergiocm;password=Th2022kkll;Convert Zero Datetime=True", x => x.ServerVersion("10.4.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Childs>(entity =>
            {
                entity.HasKey(e => e.Childid)
                    .HasName("PRIMARY");

                entity.ToTable("childs");

                entity.Property(e => e.Childid)
                    .HasColumnName("childid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido2")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnName("fechanacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasColumnName("nombre1")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasColumnName("nombre2")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Listarcabecera>(entity =>
            {
                entity.HasKey(e => e.Plistaid)
                    .HasName("PRIMARY");

                entity.ToTable("listarcabecera");

                entity.Property(e => e.Plistaid)
                    .HasColumnName("plistaid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Fechalista)
                    .HasColumnName("fechalista")
                    .HasColumnType("date");

                entity.Property(e => e.Maestroid)
                    .HasColumnName("maestroid")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<Listardetalle>(entity =>
            {
                entity.HasKey(e => e.Dlistarid)
                    .HasName("PRIMARY");

                entity.ToTable("listardetalle");

                entity.Property(e => e.Dlistarid)
                    .HasColumnName("dlistarid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Childid)
                    .HasColumnName("childid")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Plistaid)
                    .HasColumnName("plistaid")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Loginid)
                    .HasColumnName("loginid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(35)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Maestros>(entity =>
            {
                entity.HasKey(e => e.Maestroid)
                    .HasName("PRIMARY");

                entity.ToTable("maestros");

                entity.Property(e => e.Maestroid)
                    .HasColumnName("maestroid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido2")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasColumnName("nombre1")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nombre2)
                    .HasColumnName("nombre2")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Padres>(entity =>
            {
                entity.HasKey(e => e.Padreid)
                    .HasName("PRIMARY");

                entity.ToTable("padres");

                entity.Property(e => e.Padreid)
                    .HasColumnName("padreid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido2")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasColumnName("nombre1")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nombre2)
                    .HasColumnName("nombre2")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Padreshijos>(entity =>
            {
                entity.HasKey(e => e.Phid)
                    .HasName("PRIMARY");

                entity.ToTable("padreshijos");

                entity.HasIndex(e => e.Childid)
                    .HasName("fk_ppid");

                entity.HasIndex(e => e.Padreid)
                    .HasName("fk_phid");

                entity.Property(e => e.Phid)
                    .HasColumnName("phid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Childid)
                    .HasColumnName("childid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Padreid)
                    .HasColumnName("padreid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Padreshijos)
                    .HasForeignKey(d => d.Childid)
                    .HasConstraintName("fk_ppid");

                entity.HasOne(d => d.Padre)
                    .WithMany(p => p.Padreshijos)
                    .HasForeignKey(d => d.Padreid)
                    .HasConstraintName("fk_phid");
            });

            modelBuilder.Entity<Porceptrimestre>(entity =>
            {
                entity.HasKey(e => e.Ptrimestreid)
                    .HasName("PRIMARY");

                entity.ToTable("porceptrimestre");

                entity.Property(e => e.Ptrimestreid)
                    .HasColumnName("ptrimestreid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Childid)
                    .HasColumnName("childid")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Porcasistencia)
                    .HasColumnName("porcasistencia")
                    .HasColumnType("float(3,2)");
            });

            modelBuilder.Entity<Tallazapatos>(entity =>
            {
                entity.HasKey(e => e.Tallazapid)
                    .HasName("PRIMARY");

                entity.ToTable("tallazapatos");

                entity.HasIndex(e => e.Childid)
                    .HasName("fk_tzchild");

                entity.Property(e => e.Tallazapid)
                    .HasColumnName("tallazapid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Childid)
                    .HasColumnName("childid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Talla)
                    .HasColumnName("talla")
                    .HasColumnType("int(2)");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Tallazapatos)
                    .HasForeignKey(d => d.Childid)
                    .HasConstraintName("fk_tzchild");
            });

            modelBuilder.Entity<Trimestreyear>(entity =>
            {
                entity.HasKey(e => e.Tyearid)
                    .HasName("PRIMARY");

                entity.ToTable("trimestreyear");

                entity.Property(e => e.Tyearid)
                    .HasColumnName("tyearid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Cantdomingos)
                    .HasColumnName("cantdomingos")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Trimestre)
                    .HasColumnName("trimestre")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
