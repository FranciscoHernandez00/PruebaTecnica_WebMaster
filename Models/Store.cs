using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nombre { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Direccion { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Telefono { get; set; }

        public decimal Longitud { get; set; }

        public decimal Altitud { get; set; }
    }
}
