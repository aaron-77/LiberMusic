using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MSListasDeReproduccion.Validaciones
{
    public class Validaciones
    {

        public enum ResultadosValidacion
        {

          

            NúmeroVálido,
            NúmeroInválido


        }








        public ResultadosValidacion ValidarNúmero(string número)
        {
            string patrón = @"^-[0-9]*$";
            if (Regex.IsMatch(número, patrón))
            {
                return ResultadosValidacion.NúmeroVálido;
            }
            return ResultadosValidacion.NúmeroInválido;
        }
    }
}
