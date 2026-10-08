using System;
using System.Collections.Generic;
using System.Text;

namespace apicampeonatosfifa.dominio.Dtos
{
    public  class TablaPosicionDto
    {
        public int Posicion {  get; set; }
        public string Pais { get; set; }
        public int PJ {  get; set; }
        public int PG { get; set; }
        public int PE { get; set; }
        public int PP { get; set; }
        public int GF { get; set; }
        public int GC { get; set; }
        public int Diferencia { get; set; }
        public int Puntos { get; set; }

    }
}
