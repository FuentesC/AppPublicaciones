using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublicaciones.Entidades
{
    public class Publicacion
    {
        public int idTema { get; set; }
        public int idUsuario { get; set;}
        public string titulo { get; set; }
        public string mensaje { get; set; }
    }
}
