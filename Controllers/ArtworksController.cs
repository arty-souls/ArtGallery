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
using Microsoft.AspNetCore.Authorization;

namespace ArtGallery.Controllers
{
   
    public class ArtworksController : Controller
    {
        private readonly ArtworkContext _context;
        private IWebHostEnvironment _hostEnvironment;
        public ArtworksController(ArtworkContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Artworks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artworks.ToListAsync());
        }

        // GET: Artworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks
                .FirstOrDefaultAsync(m => m.ArtworkId == id);
            if (artwork == null)
            {
                return NotFound();
            }

            return View(artwork);
        }

        // GET: Artworks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtworkId,ArtworkName,ArtworkDesc,ArtistName,ArtistIg,Reference,Collection,Price,ArtworkPicture")] Artwork artwork)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(artwork.ArtworkPicture.FileName);
                string extension = Path.GetExtension(artwork.ArtworkPicture.FileName);
                artwork.ImageName = fileName = fileName + extension;
                string path = Path.Combine(wwwRootPath + "/Images/Artwork/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await artwork.ArtworkPicture.CopyToAsync(fileStream);
                }


                _context.Add(artwork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artwork);
        }

        // GET: Artworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // POST: Artworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtworkId,ArtworkName,ArtworkDesc,ArtistName,ArtistIg,Reference,Collection,Price,ImageName")] Artwork artwork)
        {
            if (id != artwork.ArtworkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artwork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtworkExists(artwork.ArtworkId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(artwork);
        }

        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Artwork model)
        {
            if (id != model.ArtworkId)
            {
                return NotFound();
            }
            string wwwRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var artwork = await _context.Artworks.FindAsync(model.ArtworkId);


            if (files.Count > 0)
            {

                var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images/Artwork", artwork.ImageName);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);

                string fileName = Path.GetFileNameWithoutExtension(model.ArtworkPicture.FileName);
                string extension = Path.GetExtension(model.ArtworkPicture.FileName);
                model.ImageName = fileName = fileName + extension;
                string path = Path.Combine(wwwRootPath + "/Images/Artwork/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                artwork.ImageName = model.ImageName;

            }


            artwork.ArtworkName = model.ArtworkName;
            artwork.ArtworkDesc = model.ArtworkDesc;
            artwork.ArtistName = model.ArtistName;
            artwork.ArtistIg = model.ArtistIg;
            artwork.Reference = model.Reference;
            artwork.Collection = model.Collection;
            artwork.Price = model.Price;
          


            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }


        // GET: Artworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks
                .FirstOrDefaultAsync(m => m.ArtworkId == id);
            if (artwork == null)
            {
                return NotFound();
            }

            return View(artwork);
        }

        // POST: Artworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);


            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images/Artwork", artwork.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            _context.Artworks.Remove(artwork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Desc(string sortOrder,string searchString)
        {
            ViewData["PriceSort"] = sortOrder == "Price" ? "price_desc" : "Price";


            var artwork = from a in _context.Artworks
                          select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                artwork = artwork.Where(s => s.ArtworkName.Contains(searchString) || s.ArtistName.Contains(searchString));
            }

                switch (sortOrder)
                {
                    case "Price":
                        artwork = artwork.OrderBy(s => s.Price);
                        break;
                    case "price_desc":
                        artwork = artwork.OrderByDescending(s => s.Price);
                        break;
                    default:
                        artwork = artwork.OrderBy(s => s.ArtworkName);
                        break;
                }
            

            return View(await artwork.ToListAsync());
        }

           
        private bool ArtworkExists(int id)
        {
            return _context.Artworks.Any(e => e.ArtworkId == id);
        }




        //sharaha
        public async Task<IActionResult> Collections()
        {
            
            var artwork = from a in _context.Artworks
                          select a;      

            return View(await artwork.ToListAsync());
        }
        public IActionResult Zodiac()
        {
            string searching = "Zodiac";
            var items = from s in _context.Artworks
                        select s;
            if (!String.IsNullOrEmpty(searching))
            {
                items = items.Where(s => s.Collection.Contains(searching));
            }
            return View(items.ToList());
        }

        public IActionResult Party()
        {
            string searching = "Party";
            var items = from s in _context.Artworks
                        select s;
            if (!String.IsNullOrEmpty(searching))
            {
                items = items.Where(s => s.Collection.Contains(searching));
            }
            return View(items.ToList());
        }

        public IActionResult Blue()
        {
            string searching = "Blue";
            var items = from s in _context.Artworks
                        select s;
            if (!String.IsNullOrEmpty(searching))
            {
                items = items.Where(s => s.Collection.Contains(searching));
            }
            return View(items.ToList());
        }

    }
}
