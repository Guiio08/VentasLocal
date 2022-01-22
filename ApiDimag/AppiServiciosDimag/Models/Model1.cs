using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AppiServiciosDimag.Models
{
  public partial class Model1 : DbContext
  {
    public Model1()
        : base("name=Model1")
    {
    }

    public virtual DbSet<Clientes> Clientes { get; set; }
    public virtual DbSet<ColorEmbone> ColorEmbone { get; set; }
    public virtual DbSet<ColorUniforme> ColorUniforme { get; set; }
    public virtual DbSet<Modelos> Modelos { get; set; }
    public virtual DbSet<OrdenCompra> OrdenCompra { get; set; }
    public virtual DbSet<PedidoUniforme> PedidoUniforme { get; set; }
    public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Clientes>()
          .Property(e => e.celular_cliente)
          .IsFixedLength();

      modelBuilder.Entity<ColorEmbone>()
          .Property(e => e.color_embone)
          .IsFixedLength();

      modelBuilder.Entity<ColorUniforme>()
          .Property(e => e.color)
          .IsFixedLength();

      modelBuilder.Entity<Modelos>()
          .Property(e => e.nombre_modelo)
          .IsFixedLength();

      modelBuilder.Entity<PedidoUniforme>()
          .Property(e => e.genero_uniforme)
          .IsFixedLength();

      modelBuilder.Entity<PedidoUniforme>()
          .Property(e => e.talla)
          .IsFixedLength();

      modelBuilder.Entity<Usuarios>()
          .Property(e => e.contrasena_usuario)
          .IsFixedLength();
    }
  }
}
