using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SingleSong.Data
{
    public class AppDbContext :DbContext
    {
       protected readonly IConfiguration Configuration;
       
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    
        }
        public DbSet<BD1> SongsBD1 { get; set; }
        public DbSet<BD2> SingerBD2 { get; set; }
        public DbSet<BD3> UsersBD3 { get; set; }
    }
}
