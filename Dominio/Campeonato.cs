using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace apicampeonatosfifa.dominio
{
    [Table("Campeonato")]
    public class Campeonato
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Campeonato")]
        public required string Nombre { get; set; }

        [Column("PaisesXGrupo")]
        public int PaisesXGrupo { get; set; } = 4;

        [Column("Año")]
        public int Año { get; set; }


    }
}
