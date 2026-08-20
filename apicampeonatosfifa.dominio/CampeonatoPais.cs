using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace apicampeonatosfifa.dominio
{
    [Table("CampeonatoPais")]
    public class CampeonatoPais
    {
        [Column("IdPais")]
        public int IdPais { get; set; }

        [Column("IdCampeonato")]
        public int IdCampeonato { get; set; }

        public Seleccion? Pais { get; set; }

        public Campeonato? Campeonato { get; set; }
    }
}
