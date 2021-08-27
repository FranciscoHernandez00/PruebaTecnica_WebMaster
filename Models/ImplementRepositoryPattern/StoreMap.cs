﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern
{
    public class StoreMap
    {
        public StoreMap(EntityTypeBuilder<Store> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired();
            entityBuilder.Property(x => x.Phone).IsRequired();
            entityBuilder.Property(x => x.Longitude).HasPrecision(9, 6).IsRequired();
            entityBuilder.Property(x => x.Latitude).HasPrecision(9, 6).IsRequired();

        }
    }
}
