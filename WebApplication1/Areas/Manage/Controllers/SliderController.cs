using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SliderController(AppDbContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            this._environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.sliders.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]


        public IActionResult Create(Slider slider)
        {

            if (!ModelState.IsValid) return View();

            string fileName = Guid.NewGuid() + slider.PhotoFile.FileName;
            string path = _environment.WebRootPath + @"\Upload\";

            using (FileStream stream = new FileStream(path + fileName, FileMode.Create))
            {
                slider.PhotoFile.CopyTo(stream);
            }
            slider.ImgUrl = fileName;
            _context.sliders.Add(slider);
            _context.SaveChanges();


            return RedirectToAction("Index");

        }


        public IActionResult Update(int id)
        {
            Slider portofolio = _context.sliders.FirstOrDefault(x => x.Id == id);

            if (portofolio == null)
            {
                return RedirectToAction("Index");
            }

            return View(portofolio);
        }

        [HttpPost]
        public IActionResult Update(Slider newportofolio)
        {
        Slider oldportofolio = _context.sliders.FirstOrDefault(x => x.Id == newportofolio.Id);

                if (!ModelState.IsValid)
                {
                   return View(oldportofolio);

                }
                if (newportofolio.PhotoFile != null)
               {
                    string fileName = Guid.NewGuid() + newportofolio.PhotoFile.FileName;
                    string path = _environment.WebRootPath + @"\Upload\";

                   using (FileStream stream = new FileStream(path + fileName, FileMode.Create))
                    {
                        newportofolio.PhotoFile.CopyTo(stream);
                    }
                    oldportofolio.ImgUrl = fileName;
                }

                oldportofolio.FullName = newportofolio.FullName;
                oldportofolio.Description = newportofolio.Description;
                oldportofolio.Position = newportofolio.Position;

                _context.SaveChanges();
                return RedirectToAction("Index");
         }


            public IActionResult Delete(int id)
            {
                Slider portofolio = _context.sliders.FirstOrDefault(x => x.Id == id);
                if (portofolio == null) return NotFound();


                string imagePath = Path.Combine(_environment.WebRootPath, "Upload", portofolio.ImgUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                _context.sliders.Remove(portofolio);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

    }
}

