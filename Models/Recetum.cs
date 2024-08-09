using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class Recetum
{
    public int IdReceta { get; set; }

    public int? Cantidad { get; set; }

    public int? MateriaPIdMateriaP { get; set; }

    public int? ProductoIdProducto { get; set; }

    public virtual MateriaP? MateriaPIdMateriaPNavigation { get; set; }

    public virtual Producto? ProductoIdProductoNavigation { get; set; }
}
