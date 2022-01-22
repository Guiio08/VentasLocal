namespace AppiServiciosDimag.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoUniforme")]
    public partial class PedidoUniforme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PedidoUniforme()
        {
            OrdenCompra = new HashSet<OrdenCompra>();
        }

        [Key]
        public int id_pedido_uniforme { get; set; }

        [StringLength(10)]
        public string genero_uniforme { get; set; }

        public int? precio_venta { get; set; }

        [StringLength(4)]
        public string talla { get; set; }

        public int? id_color_uniforme { get; set; }

        public int? id_color_embone { get; set; }

        public int? id_modelo { get; set; }

        public int? cantidad { get; set; }

        public virtual ColorEmbone ColorEmbone { get; set; }

        public virtual ColorUniforme ColorUniforme { get; set; }

        public virtual Modelos Modelos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
    }
}
