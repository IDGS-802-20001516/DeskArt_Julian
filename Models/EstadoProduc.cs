using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class EstadoProduc
{
    public int IdEstadoProduc { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Produccion> Produccions { get; set; } = new List<Produccion>();
}
