using System;
using System.Collections.Generic;

namespace Prueba_Insi.Models;

public partial class Tutore
{
    public int IdTutor { get; set; }

    public int? IdEstudiante { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string RelacionConEstudiante { get; set; } = null!;

    public virtual Estudiante? oEstudiante { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
