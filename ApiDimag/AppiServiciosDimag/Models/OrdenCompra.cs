namespace AppiServiciosDimag.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdenCompra")]
    public partial class OrdenCompra
    {
        [Key]
        public int id_orden_compra { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_pedido { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_entrega { get; set; }

        public int? id_cliente { get; set; }

        public int? id_usuario { get; set; }

        public int? id_pedido_uniforme { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual PedidoUniforme PedidoUniforme { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
