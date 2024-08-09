using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DecoArtp1.Models;

public partial class Recetum
{
    public int IdReceta { get; set; }

    public int? Cantidad { get; set; }

    public int? MateriaPIdMateriaP { get; set; }

    public int? ProductoIdProducto { get; set; }
    [JsonIgnore]

    public virtual MateriaP? MateriaPIdMateriaPNavigation { get; set; }
    [JsonIgnore]

    public virtual Producto? ProductoIdProductoNavigation { get; set; }
}
