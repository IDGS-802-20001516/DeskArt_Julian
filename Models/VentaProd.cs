using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class VentaProd
{
    public int IdVentaProd { get; set; }

    public int? Cantidad { get; set; }

    public double? SubTotal { get; set; }

    public int? UsuarioTiendaIdUsuarioTienda1 { get; set; }

    public int? UsuarioIdUsuario { get; set; }

    public int? ProductoIdProducto { get; set; }

    public virtual Producto? ProductoIdProductoNavigation { get; set; }

    public virtual Usuario? UsuarioIdUsuarioNavigation { get; set; }

    public virtual UsuarioTiendum? UsuarioTiendaIdUsuarioTienda1Navigation { get; set; }

    public virtual ICollection<VentaTotal> VentaTotals { get; set; } = new List<VentaTotal>();
}
