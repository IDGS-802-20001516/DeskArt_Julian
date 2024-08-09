using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class CompraTotal
{
    public int IdCompra { get; set; }

    public string? Descripcion { get; set; }

    public double? Total { get; set; }

    public int? CompraProdIdCompraProd { get; set; }

    public virtual CompraProd? CompraProdIdCompraProdNavigation { get; set; }
}
