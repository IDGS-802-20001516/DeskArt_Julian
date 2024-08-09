using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Empresa { get; set; }

    public string? Nombrep { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<ProveedorHasMateriaP> ProveedorHasMateriaPs { get; set; } = new List<ProveedorHasMateriaP>();
}
