using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublicaciones.Entidades.Response
{
    public class ResBase
    {
        public bool result { get; set; }
        public List<string> ListaDeErrores { get; set; }
    }
}
