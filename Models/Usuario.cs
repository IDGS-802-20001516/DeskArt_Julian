using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contrasenia { get; set; }

    public string? Colonia { get; set; }

    public string? Calle { get; set; }

    public string? NumEx { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<VentaProd> VentaProds { get; set; } = new List<VentaProd>();
}
