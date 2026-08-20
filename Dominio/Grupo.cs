using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace apicampeonatosfifa.dominio
{
    [Table("Grupo")]
    public class Grupo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Grupo")]
        public required string Nombre { get; set; }

        [Column("IdCampeonato")]
        public int IdCampeonato { get; set; }

        public Campeonato? Campeonato { get; set; }

    }
}
