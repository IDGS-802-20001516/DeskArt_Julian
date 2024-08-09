using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class UsuarioTiendum
{
    public int IdUsuarioTienda { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contrasenia { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public int? Rol { get; set; }

    public int? Estatus { get; set; }

    public virtual ICollection<Merma> Mermas { get; set; } = new List<Merma>();

    public virtual ICollection<VentaProd> VentaProds { get; set; } = new List<VentaProd>();
}
