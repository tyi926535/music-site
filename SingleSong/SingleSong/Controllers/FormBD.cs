using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingleSong.Data;

namespace SingleSong.Controllers
{

    public class FormBD : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public FormBD(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddFileCard2(IFormFile files, string NameP, string NationalityP, string YearP, string GenderP)
        {

            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            string nameFile = str + ".jpg";
            if (files != null && files.Length > 0)
            {

                string uploadsFolder = Path.Combine("wwwroot", "img");

                string uniqueFileName = Path.Combine(uploadsFolder, nameFile);

                using (var fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
            }


            return RedirectToAction("CardPeople");
        }


        public async Task<IActionResult> AddFileCard1(IFormFile fileImg, IFormFile fileMp3, string NameP, string IDSingerP, string LanguageP, string YearP, string GenreP)
        {
            Guid guid1 = Guid.NewGuid();
            string str = guid1.ToString();
            string nameFileJpg = str + ".jpg";
            Guid guid2 = Guid.NewGuid();
            str = guid2.ToString();
            string nameFileMp3 = str + ".mp3";
            int idCard = Environment.TickCount;
            if (fileImg != null && fileImg.Length > 0)
            {

                string uploadsFolder = Path.Combine("wwwroot", "img");

                string uniqueFileName = Path.Combine(uploadsFolder, nameFileJpg);

                using (var fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    fileImg.CopyTo(fileStream);
                }
            }
            if (fileMp3 != null && fileMp3.Length > 0)
            {

                string uploadsFolder = Path.Combine("wwwroot", "mp3");

                string uniqueFileName = Path.Combine(uploadsFolder, nameFileMp3);

                using (var fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    fileMp3.CopyTo(fileStream);
                }
            }

            BD1 bd1 = new BD1 { ID = idCard, Name = NameP, Language = LanguageP, Year = int.Parse(YearP), Genre = GenreP, IDSinger = IDSingerP, Img = nameFileJpg, Mp3 = nameFileMp3, Quantity = 0 };

            _dbContext.SongsBD1.Add(bd1);
            await _dbContext.SaveChangesAsync();
            // _dbContext.SongsBD1.AddRange(bd1);
            // _dbContext.SaveChanges();



            return RedirectToAction("CardPeople");
        }

    }
}
