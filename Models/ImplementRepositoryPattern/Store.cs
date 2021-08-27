using PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Models
{
    public class Store : BaseEntity
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
