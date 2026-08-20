using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace apicampeonatosfifa.dominio
{
    [Table("GrupoPais")]
    public class GrupoSeleccion
    {
        [Column("IdGrupo")]
        public int IdGrupo { get; set; }

        [Column("IdPais")]
        public int IdSeleccion { get; set; }

        public Grupo? Grupo { get; set; }

        public Seleccion? Seleccion { get; set; }
    }
}
