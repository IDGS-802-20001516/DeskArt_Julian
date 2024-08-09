using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Alto { get; set; }

    public string? Largo { get; set; }

    public string? Ancho { get; set; }

    public string? Precio { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();

    public virtual ICollection<VentaProd> VentaProds { get; set; } = new List<VentaProd>();
}
