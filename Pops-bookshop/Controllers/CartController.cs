using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Pops_bookshop.enumerableClass;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Services.Interfaces;

namespace Pops_bookshop.Controllers
{
    public class CartController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartService _cartService;

        public CartController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ICartService cartService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _cartService = cartService;
        }

        // GET: CartController
        public async Task<ActionResult> ListCart()
        {
            try
            {
                string? userId = _userManager.GetUserId(User);

                if (userId == null) throw new NullException();

                List<Book> books = await _cartService.GetCartAsync(userId);

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

        // GET: CartController/Add
        public async Task<ActionResult> Add(int bookId, int redirectTo)
        {
            try
            {
                ApplicationUser? user = await _userManager.GetUserAsync(User);

                if (user == null) throw new NullException();

                await _cartService.AddToCartAsync(bookId, user);

                switch (redirectTo)
                {
                    case (int)pageToRedirect.BookIndex:
                        return RedirectToAction("ListBooks", "Book");

                    case (int)pageToRedirect.BookDetails:
                        return RedirectToAction("BookDetails", "Book", new { bookId });

                    case (int)pageToRedirect.WishlistIndex:
                        return RedirectToAction("ListWishlist", "Wishlist");

                    case (int)pageToRedirect.CartIndex:
                        return RedirectToAction("ListCart", "Cart");

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

        // GET: CartController/Remove
        public async Task<ActionResult> Remove(int bookId, int redirectTo)
        {
            try
            {
                ApplicationUser? user = await _userManager.GetUserAsync(User);

                if (user == null) throw new NullException();

                await _cartService.RemoveFromCartAsync(bookId, user);

                switch (redirectTo)
                {
                    case (int)pageToRedirect.BookIndex:
                        return RedirectToAction("ListBooks", "Book");

                    case (int)pageToRedirect.BookDetails:
                        return RedirectToAction("BookDetails", "Book", new { bookId });

                    case (int)pageToRedirect.WishlistIndex:
                        return RedirectToAction("ListWishlist", "Wishlist");

                    case (int)pageToRedirect.CartIndex:
                        return RedirectToAction("ListCart", "Cart");

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
    }
}
