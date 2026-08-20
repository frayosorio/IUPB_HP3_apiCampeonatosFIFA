using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace apicampeonatosfifa.dominio
{
    [Table("Estadio")]
    public class Estadio
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Estadio")]
        public required string Nombre { get; set; }

        [Column("IdCiudad")]
        public int IdCiudad { get; set; }

        [Column("Capacidad")]
        public int Capacidad { get; set; }


        public Ciudad? Ciudad { get; set; }

    }
}
