using Microsoft.AspNetCore.Mvc;
using AspNetCoreViewLab_NET8_FULL_VN.Models;
using System.Linq;

namespace AspNetCoreViewLab_NET8_FULL_VN.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository _repo = new BookRepository();

        // GET: /Books
        public IActionResult Index()
        {
            var books = _repo.GetBookList();
            return View(books);
        }

        // GET: /Books/Details/5
        public IActionResult Details(int id)
        {
            var book = _repo.GetBookById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // GET: /Books/Create
        public IActionResult Create()
        {
            // prepare list of available images to choose
            ViewBag.Images = GetImageList();
            return View();
        }

        // POST: /Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book model)
        {
            if (!ModelState.IsValid) {
                ViewBag.Images = GetImageList();
                return View(model);
            }
            _repo.Add(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Edit/5
        public IActionResult Edit(int id)
        {
            var book = _repo.GetBookById(id);
            if (book == null) return NotFound();
            ViewBag.Images = GetImageList();
            return View(book);
        }

        // POST: /Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book model)
        {
            if (!ModelState.IsValid) {
                ViewBag.Images = GetImageList();
                return View(model);
            }
            _repo.Update(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Delete/5
        public IActionResult Delete(int id)
        {
            var book = _repo.GetBookById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private string[] GetImageList()
        {
            // list images available in wwwroot/images/products (hard-coded names here)
            return new[] { "/images/products/b1.jpg", "/images/products/b2.jpg", "/images/products/b3.jpg", "/images/products/b4.jpg", "/images/products/b5.jpg", "/images/products/b6.jpg" };
        }
    }
}
