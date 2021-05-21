using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSuscripcion.Validations
{
    interface IValidadorGenerico
    {
        bool validarEntero(int valor,string regex);
        bool validarTexto(string valor,string regex);
       
       

    }
}
