using System;
using System.Collections.Generic;

namespace DecoArtp1.Models;

public partial class Produccion
{
    public int IdProduccion { get; set; }

    public int? VentaTotalIdVentaTotal { get; set; }

    public int? EstadoProducIdEstadoProduc { get; set; }

    public virtual EstadoProduc? EstadoProducIdEstadoProducNavigation { get; set; }

    public virtual VentaTotal? VentaTotalIdVentaTotalNavigation { get; set; }
}
