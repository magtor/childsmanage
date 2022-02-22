using System;
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
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Cursosdocentes> Cursosdocentes { get; set; }
        public virtual DbSet<Cursosniveles> Cursosniveles { get; set; }
        public virtual DbSet<Cursotipoevaluacion> Cursotipoevaluacion { get; set; }
        public virtual DbSet<Detallematriculas> Detallematriculas { get; set; }
        public virtual DbSet<Detallesgrupos> Detallesgrupos { get; set; }
        public virtual DbSet<Detallessecciones> Detallessecciones { get; set; }
        public virtual DbSet<Dias> Dias { get; set; }
        public virtual DbSet<Grados> Grados { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Horariosdias> Horariosdias { get; set; }
        public virtual DbSet<Horariosniveles> Horariosniveles { get; set; }
        public virtual DbSet<Listarcabecera> Listarcabecera { get; set; }
        public virtual DbSet<Listardetalle> Listardetalle { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Maestros> Maestros { get; set; }
        public virtual DbSet<Niveles> Niveles { get; set; }
        public virtual DbSet<Padres> Padres { get; set; }
        public virtual DbSet<Padreshijos> Padreshijos { get; set; }
        public virtual DbSet<Periodos> Periodos { get; set; }
        public virtual DbSet<Periodosacademicos> Periodosacademicos { get; set; }
        public virtual DbSet<Porceptrimestre> Porceptrimestre { get; set; }
        public virtual DbSet<Secciones> Secciones { get; set; }
        public virtual DbSet<Tallazapatos> Tallazapatos { get; set; }
        public virtual DbSet<Tipoevaluaciones> Tipoevaluaciones { get; set; }
        public virtual DbSet<Trimestreyear> Trimestreyear { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=misionesti;uid=sergiocm;password=Th2022kkll", x => x.ServerVersion("10.4.17-mariadb"));
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

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("varchar(1)")
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

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("varchar(160)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.Cursoid)
                    .HasName("PRIMARY");

                entity.ToTable("cursos");

                entity.Property(e => e.Cursoid)
                    .HasColumnName("cursoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Cursosdocentes>(entity =>
            {
                entity.HasKey(e => e.Cursodocenteid)
                    .HasName("PRIMARY");

                entity.ToTable("cursosdocentes");

                entity.HasIndex(e => e.Cursoid)
                    .HasName("fk_cursoid_curdocent");

                entity.HasIndex(e => e.Maestroid)
                    .HasName("fk_maestroid_curdocent");

                entity.Property(e => e.Cursodocenteid)
                    .HasColumnName("cursodocenteid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Cursoid)
                    .HasColumnName("cursoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Maestroid)
                    .HasColumnName("maestroid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Cursosdocentes)
                    .HasForeignKey(d => d.Cursoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cursoid_curdocent");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.Cursosdocentes)
                    .HasForeignKey(d => d.Maestroid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestroid_curdocent");
            });

            modelBuilder.Entity<Cursosniveles>(entity =>
            {
                entity.HasKey(e => e.Cursonivelid)
                    .HasName("PRIMARY");

                entity.ToTable("cursosniveles");

                entity.HasIndex(e => e.Cursoid)
                    .HasName("fk_cursoid_curniv");

                entity.HasIndex(e => e.Nivelid)
                    .HasName("fk_nivelid_curniv");

                entity.Property(e => e.Cursonivelid)
                    .HasColumnName("cursonivelid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Cursoid)
                    .HasColumnName("cursoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Nivelid)
                    .HasColumnName("nivelid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Cursosniveles)
                    .HasForeignKey(d => d.Cursoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cursoid_curniv");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.Cursosniveles)
                    .HasForeignKey(d => d.Nivelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nivelid_curniv");
            });

            modelBuilder.Entity<Cursotipoevaluacion>(entity =>
            {
                entity.HasKey(e => e.Cursotipevalid)
                    .HasName("PRIMARY");

                entity.ToTable("cursotipoevaluacion");

                entity.HasIndex(e => e.Cursoid)
                    .HasName("fk_cursoid_curstipeval");

                entity.HasIndex(e => e.Tipoevaluacionid)
                    .HasName("fk_tipoevaluacionid_curstipeval");

                entity.Property(e => e.Cursotipevalid)
                    .HasColumnName("cursotipevalid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Cursoid)
                    .HasColumnName("cursoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Tipoevaluacionid)
                    .HasColumnName("tipoevaluacionid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Cursotipoevaluacion)
                    .HasForeignKey(d => d.Cursoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cursoid_curstipeval");

                entity.HasOne(d => d.Tipoevaluacion)
                    .WithMany(p => p.Cursotipoevaluacion)
                    .HasForeignKey(d => d.Tipoevaluacionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipoevaluacionid_curstipeval");
            });

            modelBuilder.Entity<Detallematriculas>(entity =>
            {
                entity.HasKey(e => e.Detallematrid)
                    .HasName("PRIMARY");

                entity.ToTable("detallematriculas");

                entity.HasIndex(e => e.Childid)
                    .HasName("fk_id_child");

                entity.HasIndex(e => e.Gradoid)
                    .HasName("fk_gradoid_grados");

                entity.HasIndex(e => e.Periodoid)
                    .HasName("fk_periodoid");

                entity.HasIndex(e => e.Seccionid)
                    .HasName("fk_demat_seccid");

                entity.Property(e => e.Detallematrid)
                    .HasColumnName("detallematrid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Certmedico)
                    .IsRequired()
                    .HasColumnName("certmedico")
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Childid)
                    .HasColumnName("childid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Fechamatricula)
                    .HasColumnName("fechamatricula")
                    .HasColumnType("date");

                entity.Property(e => e.Gradoid)
                    .HasColumnName("gradoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Libretaest)
                    .IsRequired()
                    .HasColumnName("libretaest")
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Periodoid)
                    .HasColumnName("periodoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Seccionid)
                    .HasColumnName("seccionid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Detallematriculas)
                    .HasForeignKey(d => d.Childid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_child");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.Detallematriculas)
                    .HasForeignKey(d => d.Gradoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gradoid_grados");

                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.Detallematriculas)
                    .HasForeignKey(d => d.Periodoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_periodoid");

                entity.HasOne(d => d.Seccion)
                    .WithMany(p => p.Detallematriculas)
                    .HasForeignKey(d => d.Seccionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_demat_seccid");
            });

            modelBuilder.Entity<Detallesgrupos>(entity =>
            {
                entity.HasKey(e => e.Detallegrupid)
                    .HasName("PRIMARY");

                entity.ToTable("detallesgrupos");

                entity.HasIndex(e => e.Grupoid)
                    .HasName("fk_id_grupo");

                entity.HasIndex(e => e.Maestroid)
                    .HasName("fk_id_maestro");

                entity.HasIndex(e => e.Periodoid)
                    .HasName("fk_detallesgrupos_pid");

                entity.Property(e => e.Detallegrupid)
                    .HasColumnName("detallegrupid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Grupoid)
                    .HasColumnName("grupoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Maestroid)
                    .HasColumnName("maestroid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Periodoid)
                    .HasColumnName("periodoid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Detallesgrupos)
                    .HasForeignKey(d => d.Grupoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_grupo");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.Detallesgrupos)
                    .HasForeignKey(d => d.Maestroid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_maestro");

                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.Detallesgrupos)
                    .HasForeignKey(d => d.Periodoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detallesgrupos_pid");
            });

            modelBuilder.Entity<Detallessecciones>(entity =>
            {
                entity.HasKey(e => e.Detalleseccionid)
                    .HasName("PRIMARY");

                entity.ToTable("detallessecciones");

                entity.HasIndex(e => e.Gradoid)
                    .HasName("fk_gradoid_detsecciones");

                entity.HasIndex(e => e.Nivelid)
                    .HasName("fk_nivel_id");

                entity.HasIndex(e => e.Periodoid)
                    .HasName("fk_secc_periodoid");

                entity.HasIndex(e => e.Seccionid)
                    .HasName("fk_seccionid");

                entity.Property(e => e.Detalleseccionid)
                    .HasColumnName("detalleseccionid")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Capacidad)
                    .HasColumnName("capacidad")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Gradoid)
                    .HasColumnName("gradoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Nivelid)
                    .HasColumnName("nivelid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Periodoid)
                    .HasColumnName("periodoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Seccionid)
                    .HasColumnName("seccionid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Vacantes)
                    .HasColumnName("vacantes")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.Detallessecciones)
                    .HasForeignKey(d => d.Gradoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gradoid_detsecciones");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.Detallessecciones)
                    .HasForeignKey(d => d.Nivelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nivel_id");

                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.Detallessecciones)
                    .HasForeignKey(d => d.Periodoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_secc_periodoid");

                entity.HasOne(d => d.Seccion)
                    .WithMany(p => p.Detallessecciones)
                    .HasForeignKey(d => d.Seccionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_seccionid");
            });

            modelBuilder.Entity<Dias>(entity =>
            {
                entity.HasKey(e => e.Diaid)
                    .HasName("PRIMARY");

                entity.ToTable("dias");

                entity.Property(e => e.Diaid)
                    .HasColumnName("diaid")
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Grados>(entity =>
            {
                entity.HasKey(e => e.Gradoid)
                    .HasName("PRIMARY");

                entity.ToTable("grados");

                entity.Property(e => e.Gradoid)
                    .HasColumnName("gradoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.Grupoid)
                    .HasName("PRIMARY");

                entity.ToTable("grupos");

                entity.Property(e => e.Grupoid)
                    .HasColumnName("grupoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.HasKey(e => e.Horarioid)
                    .HasName("PRIMARY");

                entity.ToTable("horarios");

                entity.Property(e => e.Horarioid)
                    .HasColumnName("horarioid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Duracion)
                    .HasColumnName("duracion")
                    .HasColumnType("int(2)");

                entity.Property(e => e.Horafin)
                    .HasColumnName("horafin")
                    .HasColumnType("time");

                entity.Property(e => e.Horaini)
                    .HasColumnName("horaini")
                    .HasColumnType("time");
            });

            modelBuilder.Entity<Horariosdias>(entity =>
            {
                entity.HasKey(e => e.Horariodiaid)
                    .HasName("PRIMARY");

                entity.ToTable("horariosdias");

                entity.HasIndex(e => e.Diaid)
                    .HasName("fk_horarioid_horariodia");

                entity.HasIndex(e => e.Horarioid)
                    .HasName("fk_horarioid_horadia");

                entity.Property(e => e.Horariodiaid)
                    .HasColumnName("horariodiaid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Diaid)
                    .HasColumnName("diaid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Horarioid)
                    .HasColumnName("horarioid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Dia)
                    .WithMany(p => p.Horariosdias)
                    .HasForeignKey(d => d.Diaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_diaid_horariodia");

                entity.HasOne(d => d.Horario)
                    .WithMany(p => p.Horariosdias)
                    .HasForeignKey(d => d.Horarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_horarioid_horadia");
            });

            modelBuilder.Entity<Horariosniveles>(entity =>
            {
                entity.HasKey(e => e.Horarionivelid)
                    .HasName("PRIMARY");

                entity.ToTable("horariosniveles");

                entity.HasIndex(e => e.Horarioid)
                    .HasName("fk_horarioid_horaniveles");

                entity.HasIndex(e => e.Nivelid)
                    .HasName("fk_nivelid_horaniveles");

                entity.HasIndex(e => e.Periodoid)
                    .HasName("fk_periodoid_horaniveles");

                entity.Property(e => e.Horarionivelid)
                    .HasColumnName("horarionivelid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Horarioid)
                    .HasColumnName("horarioid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Nivelid)
                    .HasColumnName("nivelid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Periodoid)
                    .HasColumnName("periodoid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Horario)
                    .WithMany(p => p.Horariosniveles)
                    .HasForeignKey(d => d.Horarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_horarioid_horaniveles");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.Horariosniveles)
                    .HasForeignKey(d => d.Nivelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nivelid_horaniveles");

                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.Horariosniveles)
                    .HasForeignKey(d => d.Periodoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_periodoid_horaniveles");
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

                entity.Property(e => e.Materiaid)
                    .HasColumnName("materiaid")
                    .HasColumnType("int(10) unsigned");
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

            modelBuilder.Entity<Niveles>(entity =>
            {
                entity.HasKey(e => e.Nivelid)
                    .HasName("PRIMARY");

                entity.ToTable("niveles");

                entity.Property(e => e.Nivelid)
                    .HasColumnName("nivelid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(18)")
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

            modelBuilder.Entity<Periodos>(entity =>
            {
                entity.HasKey(e => e.Periodoid)
                    .HasName("PRIMARY");

                entity.ToTable("periodos");

                entity.Property(e => e.Periodoid)
                    .HasColumnName("periodoid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Fechafin)
                    .HasColumnName("fechafin")
                    .HasColumnType("date");

                entity.Property(e => e.Fechainicio)
                    .HasColumnName("fechainicio")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Periodosacademicos>(entity =>
            {
                entity.HasKey(e => e.Periodoacadid)
                    .HasName("PRIMARY");

                entity.ToTable("periodosacademicos");

                entity.Property(e => e.Periodoacadid)
                    .HasColumnName("periodoacadid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Fechafin)
                    .HasColumnName("fechafin")
                    .HasColumnType("date");

                entity.Property(e => e.Fechaini)
                    .HasColumnName("fechaini")
                    .HasColumnType("date");
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

            modelBuilder.Entity<Secciones>(entity =>
            {
                entity.HasKey(e => e.Seccionid)
                    .HasName("PRIMARY");

                entity.ToTable("secciones");

                entity.Property(e => e.Seccionid)
                    .HasColumnName("seccionid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
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

            modelBuilder.Entity<Tipoevaluaciones>(entity =>
            {
                entity.HasKey(e => e.Tipoevaluacionid)
                    .HasName("PRIMARY");

                entity.ToTable("tipoevaluaciones");

                entity.Property(e => e.Tipoevaluacionid)
                    .HasColumnName("tipoevaluacionid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
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
