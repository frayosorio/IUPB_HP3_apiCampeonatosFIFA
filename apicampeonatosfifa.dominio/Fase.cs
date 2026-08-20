using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace apicampeonatosfifa.dominio
{
    [Table("Fase")]
    public class Fase
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Fase")]
        public required string Nombre { get; set; }

    }
}
