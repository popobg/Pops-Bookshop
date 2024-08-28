using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Services;
using Pops_bookshop.Services.Interfaces;

namespace Pops_bookshop.Controllers
{
    public class WishlistController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWishlistService _wishlistService;

        public WishlistController(UserManager<ApplicationUser> userManager, IWishlistService wishlistService)
        {
            _userManager = userManager;
            _wishlistService = wishlistService;
        }

        // GET: HomeController1
        public async Task<ActionResult> Index()
        {
            try
            {
                string? userId = _userManager.GetUserId(User);

                if (userId == null) throw new NullException();

                List<Book> books = await _wishlistService.GetWishedBooksAsync(userId);

                return View(books);
            }
            catch (SqlException ex)
            {
                return RedirectToAction("Exception", "Home", new { message = ex.Message });
            }
            catch (NullException ex)
            {
                return RedirectToAction("Exception", "Home", new { message = ex.Message });
            }
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
