using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DecoArtp1.Models;

public partial class MateriaP
{
    public int IdMateriaP { get; set; }

    public string? Nombre { get; set; }

    public string? Medida { get; set; }

    [JsonIgnore]
    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
    [JsonIgnore]
    public virtual ICollection<Merma> Mermas { get; set; } = new List<Merma>();
    [JsonIgnore]
    public virtual ICollection<ProveedorHasMateriaP> ProveedorHasMateriaPs { get; set; } = new List<ProveedorHasMateriaP>();
    [JsonIgnore]
    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();
}
