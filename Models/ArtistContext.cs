using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class ArtistContext:DbContext
    {
        public ArtistContext(DbContextOptions<ArtistContext> options) : base(options)
        {


        }

        public DbSet<Artist> Artist { get; set; }
    }
}
