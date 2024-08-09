using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class MateriaP
{
    public int IdMateriaP { get; set; }

    public string? Nombre { get; set; }

    public string? Medida { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Merma> Mermas { get; set; } = new List<Merma>();

    public virtual ICollection<ProveedorHasMateriaP> ProveedorHasMateriaPs { get; set; } = new List<ProveedorHasMateriaP>();

    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();
}
