using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicampeonatosfifa.dominio
{
    [Table("Ciudad")]
    public class Ciudad
    {

        [Column("Id")]
        public int Id { get; set; }

        [Column("Ciudad")]
        public required string Nombre { get; set; }

        [Column("IdPais")]
        public int IdPais { get; set; }

        public Seleccion? Pais {  get; set; }

    }
}
