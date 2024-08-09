using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class VentaTotal
{
    public int IdVentaTotal { get; set; }

    public string? Descripcion { get; set; }

    public double? Total { get; set; }

    public int? VentaProdIdVentaProd { get; set; }

    public virtual ICollection<Produccion> Produccions { get; set; } = new List<Produccion>();

    public virtual VentaProd? VentaProdIdVentaProdNavigation { get; set; }
}
