
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Win32;
using SingleSong.Data;
using System.Runtime.Intrinsics.X86;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Diagnostics;


namespace SingleSong.Controllers
{
    
    public class PersonalAccountController : Controller
    {
        
        public IActionResult CardPeople()
        {
            return View();
        }
        

        protected readonly IConfiguration Configuration;
        public PersonalAccountController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        private string GeneratorGuid(string extension)
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            string nameFile = str + extension;
            return nameFile;
        }
        private void AddFile(IFormFile files,string path,string nameFile)
        {
            if (files != null && files.Length > 0)
            {

                string uploadsFolder = Path.Combine("wwwroot", path);

                string uniqueFileName = Path.Combine(uploadsFolder, nameFile);

                using (var fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
            }
        }



        [HttpGet]
        public IActionResult AddCard2() => View();
        [HttpPost]
        public async Task<IActionResult> AddCard2(IFormFile files, BD2 model)
        {
            if (ModelState.IsValid)
            {
                string nameFile = GeneratorGuid(".jpg");
                AddFile(files, "img", nameFile);
                int idCard = Environment.TickCount;
                BD2 bd2 = new BD2
                {
                    ID = idCard,
                    Name = model.Name,
                    Nationality = model.Nationality,
                    Year = model.Year,
                    Gender = model.Gender,
                    Img = nameFile,

                };

                AppDbContext appDB = new AppDbContext(Configuration);
                appDB.SingerBD2.Add(bd2);
                appDB.SaveChanges();
                return RedirectToAction("CardPeople");

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddCard1() => View();
        [HttpPost]
        public async Task<IActionResult> AddCard1(IFormFile fileImg, IFormFile fileMp3, BD1 model)
        {
            if (ModelState.IsValid)
            {
                string nameFileJpg = GeneratorGuid(".jpg");
                AddFile(fileImg, "img", nameFileJpg);
                string nameFileMp3 = GeneratorGuid(".mp3");
                AddFile(fileMp3, "mp3", nameFileMp3);
                int idCard = Environment.TickCount;


                BD1 bd1 = new BD1
                {
                    ID = idCard,
                    Name = model.Name,
                    Language = model.Language,
                    Year = model.Year,
                    Genre = model.Genre,
                    IDSinger = model.IDSinger,
                    Img = nameFileJpg,
                    Mp3 = nameFileMp3,
                    Quantity = 0
                };

                AppDbContext appDB = new AppDbContext(Configuration);
                appDB.SongsBD1.Add(bd1);
                appDB.SaveChanges();

                return RedirectToAction("CardPeople");
            }
            return View();
    }
        [HttpGet]
        public IActionResult Registration() => View();
        [HttpPost]
        public async Task<IActionResult> Registration(BD3 model, IFormFile fileImg)
        {
            if (ModelState.IsValid)
            {
                
                string nameFileJpg = GeneratorGuid(".jpg");
                AddFile(fileImg, "img", nameFileJpg);
                int idCard = Environment.TickCount;


                BD3 bd3 = new BD3
                {
                    ID = idCard,
                    Name = model.Name,
                    Password = model.Password,
                    Mail = model.Mail,
                    Img = nameFileJpg
                };

                AppDbContext appDB = new AppDbContext(Configuration);
                appDB.UsersBD3.Add(bd3);
                appDB.SaveChanges();
                
                return RedirectToAction("CardPeople");
            }
            return View();
    }


    }

    
}
