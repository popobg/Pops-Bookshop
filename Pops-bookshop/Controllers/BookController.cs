using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Services.Interfaces;

namespace Pops_bookshop.Controllers
{
    public class BookController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBookService _bookService;

        public BookController(UserManager<ApplicationUser> userManager, IBookService bookService)
        {
            _userManager = userManager;
            _bookService = bookService;
        }

        // GET: BookController
        public async Task<ActionResult> Index()
        {
            try
            {
                List<Book> books = await _bookService.GetBooksAsync();

                return View(books);
            }
            catch(DatabaseException ex)
            {
                return RedirectToAction("Exception", "Home", new { message = ex.Message });
            }
        }

        // GET: BookController/Details/5
        public ActionResult Details(int bookId)
        {
            try
            {
                Book book = await _bookService.GetBookByIdAsync(bookId);

                return View(book);
            }
            catch (DatabaseException ex)
            {
                return RedirectToAction("Exception", "Home", new { message = ex.Message });
            }
        }

        // GET: BookController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
