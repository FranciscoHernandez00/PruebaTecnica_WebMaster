using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PruebaTecnica_WebMaster.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the PruebaTecnica_WebMasterUser class
    public class PruebaTecnica_WebMasterUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Create { get; set; }

        public bool Edit { get; set; }

        public bool Delete { get; set; }

        public bool Details { get; set; }

        public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }
    }
}
