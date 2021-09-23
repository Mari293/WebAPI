using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPruebaAPI.Models;

namespace WebPruebaAPI.Data
{
    public class WebPruebaAPIContext : DbContext
    {
        public WebPruebaAPIContext (DbContextOptions<WebPruebaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebPruebaAPI.Models.books> books { get; set; }
    }
}
