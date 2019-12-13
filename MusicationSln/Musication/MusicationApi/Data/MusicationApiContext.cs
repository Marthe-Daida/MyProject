using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicationApi.Models
{
    public class MusicationApiContext : DbContext
    {
        public MusicationApiContext(DbContextOptions<MusicationApiContext> options)
            : base(options)
        {
        }

        public DbSet<MusicationApi.Models.User> Users { get; set; }
    }
}