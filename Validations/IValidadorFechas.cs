using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSuscripcion.Validations
{
    interface IValidadorFechas
    {

        bool validarFecha(string fecha, string regex);
    }
}
