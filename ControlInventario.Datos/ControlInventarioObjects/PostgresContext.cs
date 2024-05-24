using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatalogoProveedor> CatalogoProveedor { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Inventario> Inventario { get; set; }

    public virtual DbSet<Proveedor> Proveedor { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<SystemUuidKey> SystemUuidKey { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<CatalogoProveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("catalogo_proveedor_pkey");

            entity.ToTable("catalogo_proveedor");

            entity.HasIndex(e => new { e.IdProveedor, e.CodigoBarra }, "cod_barra_x_proveedor_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ArticuloProveedor)
                .HasMaxLength(40)
                .HasColumnName("articulo_proveedor");
            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(15)
                .HasColumnName("codigo_barra");
            entity.Property(e => e.Costo)
                .HasDefaultValueSql("0.1")
                .HasColumnName("costo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.CatalogoProveedor)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("provider_id_FK");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroIdentidad).HasColumnName("numero_identidad");
            entity.Property(e => e.Telefono)
                .HasColumnType("character varying")
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("factura_pkey");

            entity.ToTable("factura");

            entity.Property(e => e.IdProveedor)
                .ValueGeneratedNever()
                .HasColumnName("id_proveedor");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_factura");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.NumeroControl).HasColumnName("numero_control");
            entity.Property(e => e.NumeroFactura).HasColumnName("numero_factura");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.TotalDescuento).HasColumnName("total_descuento");
            entity.Property(e => e.TotalImpuesto).HasColumnName("total_impuesto");
            entity.Property(e => e.TotalNeto).HasColumnName("total_neto");

            entity.HasOne(d => d.IdProveedorNavigation).WithOne(p => p.Factura)
                .HasForeignKey<Factura>(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("provider_id_FK");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("inventario");

            entity.Property(e => e.CodigoArticulo)
                .HasColumnType("character varying")
                .HasColumnName("codigo_articulo");
            entity.Property(e => e.CodigoBarra)
                .HasColumnType("character varying")
                .HasColumnName("codigo_barra");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.DescripciónArticulo)
                .HasColumnType("character varying")
                .HasColumnName("descripción_articulo");
            entity.Property(e => e.Existencia)
                .HasDefaultValue(0)
                .HasColumnName("existencia");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

            entity.HasOne(d => d.Proveedor).WithMany()
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_id_FK");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Proveedor_pkey");

            entity.ToTable("proveedor");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DiasCredito)
                .HasDefaultValue(0)
                .HasColumnName("dias_credito");
            entity.Property(e => e.DiasPromedioEntrega)
                .HasDefaultValueSql("1")
                .HasColumnName("dias_promedio_entrega");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Rif)
                .HasMaxLength(10)
                .HasColumnName("rif");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("character varying")
                .HasColumnName("descripcion");
            entity.Property(e => e.Rol)
                .HasColumnType("character varying")
                .HasColumnName("rol");
        });

        modelBuilder.Entity<SystemUuidKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("system_uuid_key_pkey");

            entity.ToTable("system_uuid_key");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("creation_date");
            entity.Property(e => e.ExpirationDate)
                .HasDefaultValueSql("(CURRENT_TIMESTAMP + '2 days'::interval day)")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "email_unique").IsUnique();

            entity.HasIndex(e => e.Login, "login_unique").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasColumnType("character varying")
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.NombreCompleto)
                .HasColumnType("character varying")
                .HasColumnName("nombre_completo");
            entity.Property(e => e.RoleId)
                .HasDefaultValue(1)
                .HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_id_FK");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venta_pkey");

            entity.ToTable("venta");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFactura).HasColumnName("fecha_factura");
            entity.Property(e => e.MontoBase).HasColumnName("monto_base");
            entity.Property(e => e.MontoIva).HasColumnName("monto_iva");
            entity.Property(e => e.NumeroControl).HasColumnName("numero_control");
            entity.Property(e => e.NumeroFactura).HasColumnName("numero_factura");
            entity.Property(e => e.PorcentajeIva).HasColumnName("porcentaje_iva");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Venta)
                .HasForeignKey<Venta>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cliente_id_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
