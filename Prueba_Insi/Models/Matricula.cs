using System;
using System.Collections.Generic;

namespace Prueba_Insi.Models;

public partial class Matricula
{
    public int IdMatricula { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdTutor { get; set; }

    public DateTime FechaMatricula { get; set; }

    public string EstadoMatricula { get; set; } = null!;

    public string GradoSolicitado { get; set; } = null!;

    public virtual Estudiante? oEstudiante { get; set; }

    public virtual Tutore? oTutores { get; set; }
}
