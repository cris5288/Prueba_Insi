using System;
using System.Collections.Generic;

namespace Prueba_Insi.Models;

public partial class Usuario
{
    public int? UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public byte[]? ContraseñaEncriptada { get; set; }
}
