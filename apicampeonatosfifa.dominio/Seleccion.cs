using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicampeonatosfifa.dominio
{
    [Table("Pais")]
    public class Seleccion
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Pais")]
        public required string Nombre { get; set; }
        [Column("Entidad")]
        public string Entidad { get; set; }
    }
}
