using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtGallery.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace ArtGallery.Controllers
{ 
   
    public class ArtistsController : Controller
    {
        private IWebHostEnvironment _hostEnvironment;

      

        private readonly ArtistContext _context;

        public ArtistsController(ArtistContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }


        // GET: Artists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artist.ToListAsync());
        }


        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }


        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistId,ArtistName,ArtistDesc,ArtistCity,ArtistIg,ArtistPicture")] Artist artist)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(artist.ArtistPicture.FileName);
                string extension = Path.GetExtension(artist.ArtistPicture.FileName);
                artist.ImageName = fileName = fileName + extension;
                string path = Path.Combine(wwwRootPath + "/Images/Artist/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await artist.ArtistPicture.CopyToAsync(fileStream);
                }


                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,ArtistName,ArtistDesc,ArtistCity,ArtistIg,ArtistPicture")] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                             
                _context.Update(artist);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Artist model)
        {

            if (ModelState.IsValid)
            {
                if (model.ArtistPicture != null)
                { string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ArtistPicture.FileName);
                string extension = Path.GetExtension(model.ArtistPicture.FileName);
                model.ImageName = fileName = fileName + extension;
                string path = Path.Combine(wwwRootPath + "/Images/Artist/", fileName);


                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);

                }



                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ArtistPicture.CopyToAsync(fileStream);
                }

            }

                
                _context.Update(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

   

        // GET: Artists/Desc
        public async Task<IActionResult> Desc()
        {
            return View(await _context.Artist.ToListAsync());
        }
        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artist.FindAsync(id);


            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images/Artist", artist.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            _context.Artist.Remove(artist);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _context.Artist.Any(e => e.ArtistId == id);
        }
    }
}
