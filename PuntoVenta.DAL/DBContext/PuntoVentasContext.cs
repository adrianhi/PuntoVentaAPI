using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.Model;

namespace PuntoVenta.DAL.DBContext;

public partial class PuntoVentasContext : DbContext
{
    public PuntoVentasContext()
    {
    }

    public PuntoVentasContext(DbContextOptions<PuntoVentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<DetallesCtasxcobrar> DetallesCtasxcobrars { get; set; }

    public virtual DbSet<DetallesVenta> DetallesVentas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<MaestroCliente> MaestroClientes { get; set; }

    public virtual DbSet<MaestroCtasxcobrar> MaestroCtasxcobrars { get; set; }

    public virtual DbSet<MaestroVenta> MaestroVentas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; }

    public virtual DbSet<Transacciones> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__4A033A93F4755980");

            entity.ToTable("Categoria_productos");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("Id_categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_categoria");
        });

        modelBuilder.Entity<DetallesCtasxcobrar>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCxC).HasName("PK__Maestro___CA7A50EB6DAFD1A1");

            entity.ToTable("Detalles_ctasxcobrar");

            entity.Property(e => e.IdDetalleCxC).HasColumnName("Id_detalleCxC");
            entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdCxC).HasColumnName("Id_CxC");
            entity.Property(e => e.IdTipoTransaccion).HasColumnName("Id_TipoTransaccion");
            entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");
            entity.Property(e => e.MontoAbonado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_Abonado");
            entity.Property(e => e.RefIdTransaccion).HasColumnName("Ref_IdTransaccion");
        });

        modelBuilder.Entity<DetallesVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetallesVentas).HasName("PK__Detalles__DF050D5C67BA8826");

            entity.ToTable("Detalles_ventas");

            entity.Property(e => e.IdDetallesVentas).HasColumnName("Id_detallesVentas");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.IdTipoTransaccion).HasColumnName("Id_TipoTransaccion");
            entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");
            entity.Property(e => e.IdVenta).HasColumnName("Id_venta");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_venta");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetallesVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK_DetallesVentas_MaestroVentas");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Facturas__A8B88C222FE1B941");

            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.IdTipoTransaccion).HasColumnName("Id_TipoTransaccion");
            entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPagado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Pagado");
        });

        modelBuilder.Entity<MaestroCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Maestro___885457EE669DA3FF");

            entity.ToTable("Maestro_Clientes");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("idCliente");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<MaestroCtasxcobrar>(entity =>
        {
            entity.HasKey(e => e.IdCxC).HasName("PK__Maestro___5113BCE4C9EE41FF");

            entity.ToTable("Maestro_ctasxcobrar");

            entity.Property(e => e.IdCxC).HasColumnName("Id_CxC");
            entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.IdTipoTransaccion).HasColumnName("Id_TipoTransaccion");
            entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");
            entity.Property(e => e.IdVenta).HasColumnName("Id_venta");
            entity.Property(e => e.MontoRecibido)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_recibido");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_total");
        });

        modelBuilder.Entity<MaestroVenta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK_MaestroVentas_IdVenta");

            entity.ToTable("Maestro_ventas");

            entity.Property(e => e.IdVenta).HasColumnName("Id_venta");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.IdTipoTransaccion).HasColumnName("Id_TipoTransaccion");
            entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");
            entity.Property(e => e.MontoRecibido)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_recibido");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_total");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__1D8EFF01E0C4389A");

            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IdCategoria).HasColumnName("Id_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioCompra)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_compra");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_venta");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Productos__Id_ca__3B75D760");
        });

        modelBuilder.Entity<TipoTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdTipoTransaccion);

            entity.ToTable("Tipo_Transaccion");

            entity.Property(e => e.IdTipoTransaccion).HasColumnName("Id_TipoTransaccion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FactContado).HasColumnName("Fact_contado");
            entity.Property(e => e.FactCredito).HasColumnName("Fact_Credito");
            entity.Property(e => e.ReciboCobro).HasColumnName("Recibo_Cobro");
        });

        modelBuilder.Entity<Transacciones>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion);

            entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.TipoTransaccionId).HasColumnName("Tipo_transaccion_id");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
