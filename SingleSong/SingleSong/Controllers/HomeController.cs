using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingleSong.Data;
using SingleSong.Models;
using System.Diagnostics;

namespace SingleSong.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly IConfiguration Configuration;
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */


        public IActionResult Index()
        {
            var arraySongsData = new List<SongsData>();
            AppDbContext appDB = new AppDbContext(Configuration);

            var bd1 = appDB.SongsBD1.FromSqlRaw("SELECT * FROM \"SongsBD1\" ORDER BY \"Quantity\" DESC Limit 10").ToList();
            foreach (var i in bd1)
            {
                arraySongsData.Add(new SongsData { ID = i.ID, Name = i.Name, Singer = i.IDSinger ,Img=i.Img});
            }
            ViewBag.ArraySD = arraySongsData;
            return View();
        }
        public IActionResult CardSong()
        {
            return View();
        }
        public IActionResult Entrance()
        {
            return View();
        }
        
        public IActionResult CardSinger()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search( string wordT)
        
        {
            var arraySongsData = new List<SongsData>();
            AppDbContext appDB = new AppDbContext(Configuration);
            ViewBag.ArraySD = arraySongsData;
            ViewBag.Word=wordT;
            if (wordT != null)
            {
                wordT = wordT.Replace(" ", "");

                var bd1 = appDB.SongsBD1.FromSqlRaw("SELECT * FROM \"SongsBD1\" where (Lower(\"Name\") Like Lower('%" + wordT + "%')) or(Lower(\"IDSinger\") Like Lower('%ll%'))").ToList();
                foreach (var i in bd1)
                {
                    arraySongsData.Add(new SongsData { ID = i.ID, Name = i.Name, Singer = i.IDSinger, Img = i.Img });
                }
                ViewBag.ArraySD = arraySongsData;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    internal class SongsData
    {
        public string Name { get; set; }
        public string Singer { get; set; }
        public int ID { get; set; }
        public string Img { get; set; }
    }

    
   
 }
