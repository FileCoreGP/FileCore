using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FileCore.Models
{
    public partial class filecoreContext : DbContext
    {
        public filecoreContext()
        {
        }

        public filecoreContext(DbContextOptions<filecoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Capacitaciones> Capacitaciones { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Datospariente> Datospariente { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Empleosanteriores> Empleosanteriores { get; set; }
        public virtual DbSet<Evidencias> Evidencias { get; set; }
        public virtual DbSet<Evidenciasempleado> Evidenciasempleado { get; set; }
        public virtual DbSet<Gradoescolaridad> Gradoescolaridad { get; set; }
        public virtual DbSet<HistorialcategoriasPuestos> HistorialcategoriasPuestos { get; set; }
        public virtual DbSet<PremiosReconocimientos> PremiosReconocimientos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost; user id=root; password=root; database=filecore;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Capacitaciones>(entity =>
            {
                entity.HasKey(e => e.IdCapacitaciones);

                entity.ToTable("capacitaciones");

                entity.HasIndex(e => e.EmpleadoIdEmpleado)
                    .HasName("fk_Capacitaciones_Empleado1_idx");

                entity.Property(e => e.IdCapacitaciones).HasColumnType("int(11)");

                entity.Property(e => e.EmpleadoIdEmpleado)
                    .HasColumnName("Empleado_IdEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreCapacitacion)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation)
                    .WithMany(p => p.Capacitaciones)
                    .HasForeignKey(d => d.EmpleadoIdEmpleado)
                    .HasConstraintName("fk_Capacitaciones_Empleado1");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Datospariente>(entity =>
            {
                entity.HasKey(e => e.IdDatosPariente);

                entity.ToTable("datospariente");

                entity.HasIndex(e => e.EmpleadoIdEmpleado)
                    .HasName("fk_DatosPariente_Empleado1_idx");

                entity.Property(e => e.IdDatosPariente).HasColumnType("int(11)");

                entity.Property(e => e.Avisar).HasColumnType("bit(1)");

                entity.Property(e => e.EmpleadoIdEmpleado)
                    .HasColumnName("Empleado_IdEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TelefonoContacto).HasColumnType("varchar(10)");

                entity.Property(e => e.TipoParentesco)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation)
                    .WithMany(p => p.Datospariente)
                    .HasForeignKey(d => d.EmpleadoIdEmpleado)
                    .HasConstraintName("fk_DatosPariente_Empleado1");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.ToTable("departamento");

                entity.Property(e => e.IdDepartamento).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(80)");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("empleado");

                entity.HasIndex(e => e.CategoriaIdCategoria)
                    .HasName("fk_Empleado_Categoria1_idx");

                entity.HasIndex(e => e.DepartamentoIdDepartamento)
                    .HasName("fk_Empleado_Departamento1_idx");

                entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.ApMaterno)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.ApPaterno)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.CategoriaIdCategoria)
                    .HasColumnName("Categoria_IdCategoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartamentoIdDepartamento)
                    .HasColumnName("Departamento_IdDepartamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.HasOne(d => d.CategoriaIdCategoriaNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.CategoriaIdCategoria)
                    .HasConstraintName("fk_Empleado_Categoria1");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.DepartamentoIdDepartamento)
                    .HasConstraintName("fk_Empleado_Departamento1");
            });

            modelBuilder.Entity<Empleosanteriores>(entity =>
            {
                entity.HasKey(e => e.IdEmpleosAnteriores);

                entity.ToTable("empleosanteriores");

                entity.HasIndex(e => e.EmpleadoIdEmpleado)
                    .HasName("fk_EmpleosAnteriores_Empleado1_idx");

                entity.Property(e => e.IdEmpleosAnteriores).HasColumnType("int(11)");

                entity.Property(e => e.EmpleadoIdEmpleado)
                    .HasColumnName("Empleado_IdEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.FechaTerminacion).HasColumnType("date");

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation)
                    .WithMany(p => p.Empleosanteriores)
                    .HasForeignKey(d => d.EmpleadoIdEmpleado)
                    .HasConstraintName("fk_EmpleosAnteriores_Empleado1");
            });

            modelBuilder.Entity<Evidencias>(entity =>
            {
                entity.HasKey(e => e.IdEvidencias);

                entity.ToTable("evidencias");

                entity.Property(e => e.IdEvidencias).HasColumnType("int(11)");

                entity.Property(e => e.AdmiteComprobante).HasColumnType("bit(1)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Orden).HasColumnType("int(11)");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Evidenciasempleado>(entity =>
            {
                entity.HasKey(e => e.IdEvidenciaEmpleado);

                entity.ToTable("evidenciasempleado");

                entity.HasIndex(e => e.EmpleadoIdEmpleado)
                    .HasName("fk_Empleado_has_Evidencias_Empleado1_idx");

                entity.HasIndex(e => e.EvidenciasIdEvidencias)
                    .HasName("fk_Empleado_has_Evidencias_Evidencias1_idx");

                entity.Property(e => e.IdEvidenciaEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EmpleadoIdEmpleado)
                    .HasColumnName("Empleado_IdEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EvidenciasIdEvidencias)
                    .HasColumnName("Evidencias_IdEvidencias")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation)
                    .WithMany(p => p.Evidenciasempleado)
                    .HasForeignKey(d => d.EmpleadoIdEmpleado)
                    .HasConstraintName("fk_Empleado_has_Evidencias_Empleado1");

                entity.HasOne(d => d.EvidenciasIdEvidenciasNavigation)
                    .WithMany(p => p.Evidenciasempleado)
                    .HasForeignKey(d => d.EvidenciasIdEvidencias)
                    .HasConstraintName("fk_Empleado_has_Evidencias_Evidencias1");
            });

            modelBuilder.Entity<Gradoescolaridad>(entity =>
            {
                entity.HasKey(e => e.IdGradoEscolaridad);

                entity.ToTable("gradoescolaridad");

                entity.HasIndex(e => e.EmpleadoIdEmpleado)
                    .HasName("fk_GradoEscolaridad_Empleado1_idx");

                entity.Property(e => e.IdGradoEscolaridad).HasColumnType("int(11)");

                entity.Property(e => e.Cedula).HasColumnType("varchar(10)");

                entity.Property(e => e.EmpleadoIdEmpleado)
                    .HasColumnName("Empleado_IdEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Institucion)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.NivelAcademico)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.NombreGrado).HasColumnType("varchar(10)");

                entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation)
                    .WithMany(p => p.Gradoescolaridad)
                    .HasForeignKey(d => d.EmpleadoIdEmpleado)
                    .HasConstraintName("fk_GradoEscolaridad_Empleado1");
            });

            modelBuilder.Entity<HistorialcategoriasPuestos>(entity =>
            {
                entity.HasKey(e => e.IdHistorialCategoriasPuestos);

                entity.ToTable("historialcategorias-puestos");

                entity.HasIndex(e => e.CategoriaIdCategoria)
                    .HasName("fk_HistorialCategorias-Puestos_Categoria1_idx");

                entity.HasIndex(e => e.DepartamentoIdDepartamento)
                    .HasName("fk_HistorialCategorias-Puestos_Departamento1_idx");

                entity.HasIndex(e => e.EmpleadoIdEmpleado)
                    .HasName("fk_HistorialCategorias-Puestos_Empleado1_idx");

                entity.Property(e => e.IdHistorialCategoriasPuestos)
                    .HasColumnName("IdHistorialCategorias-Puestos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriaIdCategoria)
                    .HasColumnName("Categoria_IdCategoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartamentoIdDepartamento)
                    .HasColumnName("Departamento_IdDepartamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmpleadoIdEmpleado)
                    .HasColumnName("Empleado_IdEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaInicioCategoria).HasColumnType("date");

                entity.Property(e => e.FechaInicioDepartamento).HasColumnType("date");

                entity.HasOne(d => d.CategoriaIdCategoriaNavigation)
                    .WithMany(p => p.HistorialcategoriasPuestos)
                    .HasForeignKey(d => d.CategoriaIdCategoria)
                    .HasConstraintName("fk_HistorialCategorias-Puestos_Categoria1");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNavigation)
                    .WithMany(p => p.HistorialcategoriasPuestos)
                    .HasForeignKey(d => d.DepartamentoIdDepartamento)
                    .HasConstraintName("fk_HistorialCategorias-Puestos_Departamento1");

                entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation)
                    .WithMany(p => p.HistorialcategoriasPuestos)
                    .HasForeignKey(d => d.EmpleadoIdEmpleado)
                    .HasConstraintName("fk_HistorialCategorias-Puestos_Empleado1");
            });

            modelBuilder.Entity<PremiosReconocimientos>(entity =>
            {
                entity.HasKey(e => e.IdPremiosReconocimientos);

                entity.ToTable("premios-reconocimientos");

                entity.HasIndex(e => e.EmpleadoIdEmpleado)
                    .HasName("fk_Premios-Reconocimientos_Empleado1_idx");

                entity.Property(e => e.IdPremiosReconocimientos)
                    .HasColumnName("IdPremios-Reconocimientos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.EmpleadoIdEmpleado)
                    .HasColumnName("Empleado_IdEmpleado")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation)
                    .WithMany(p => p.PremiosReconocimientos)
                    .HasForeignKey(d => d.EmpleadoIdEmpleado)
                    .HasConstraintName("fk_Premios-Reconocimientos_Empleado1");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios);

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuarios).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.Rol).HasColumnType("int(11)");
            });
        }
    }
}
