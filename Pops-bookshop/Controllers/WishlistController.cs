using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Pops_bookshop.enumerableClass;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Services.Interfaces;

namespace Pops_bookshop.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWishlistService _wishlistService;

        public WishlistController(UserManager<ApplicationUser> userManager, IWishlistService wishlistService)
        {
            _userManager = userManager;
            _wishlistService = wishlistService;
        }

        // GET: WishlistController
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

        public async Task<ActionResult> Add(int bookId, int redirectTo)
        {
            try
            {
                ApplicationUser? user = await _userManager.GetUserAsync(User);

                if (user == null) throw new NullException();

                await _wishlistService.AddBookToWishlistAsync(bookId, user);

                switch (redirectTo)
                {
                    case (int)pageToRedirect.BookIndex:
                        return RedirectToAction("Index", "Book");

                    case (int)pageToRedirect.BookDetails:
                        return RedirectToAction("Details", "Book", new { bookId });

                    default:
                        return RedirectToAction("Index", "Home");
                }
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

        public async Task<ActionResult> Delete(int bookId, int redirectTo)
        {
            try
            {

                return View();
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
    }
}
