using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class CompraProd
{
    public int IdCompraProd { get; set; }

    public int? Cantidad { get; set; }

    public int? SubTotal { get; set; }

    public int? ProveedorHasMateriaPIdProveedorHasMateriaP { get; set; }

    public virtual ICollection<CompraTotal> CompraTotals { get; set; } = new List<CompraTotal>();

    public virtual ProveedorHasMateriaP? ProveedorHasMateriaPIdProveedorHasMateriaPNavigation { get; set; }
}
