using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern
{
    public class StoreViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]

        public string Address { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public decimal Latitude { get; set; }


        public string Coordinates { get; set; }
    }
}
