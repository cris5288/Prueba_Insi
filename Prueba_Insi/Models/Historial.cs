﻿using System;
using System.Collections.Generic;

namespace Prueba_Insi.Models;

public partial class Historial
{
    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public string? Usuario { get; set; }

    public int? IdMatricula { get; set; }
}
