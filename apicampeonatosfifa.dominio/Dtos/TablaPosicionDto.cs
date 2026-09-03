using System;
using System.Collections.Generic;
using System.Text;

namespace apicampeonatosfifa.dominio.Dtos
{
    public  class TablaPosicionDto
    {
        int Posicion {  get; set; }
        string Seleccion { get; set; }
        int PJ {  get; set; }
        int PG { get; set; }
        int PE { get; set; }
        int PP { get; set; }
        int PJ { get; set; }
        int GF { get; set; }
        int GC { get; set; }
        int Diferencia { get; set; }
        int Puntos { get; set; }

    }
}
