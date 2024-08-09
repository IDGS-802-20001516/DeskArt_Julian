using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class ProveedorHasMateriaP
{
    public int IdProveedorHasMateriaP { get; set; }

    public int? MateriaPIdMateriaP1 { get; set; }

    public int? ProveedorIdProveedor1 { get; set; }

    public virtual ICollection<CompraProd> CompraProds { get; set; } = new List<CompraProd>();

    public virtual MateriaP? MateriaPIdMateriaP1Navigation { get; set; }

    public virtual Proveedor? ProveedorIdProveedor1Navigation { get; set; }
}
