using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pops_bookshop.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(35)]
        public string Firstname { get; set; } = string.Empty;

        [Required]
        [MaxLength(35)]
        public string Lastname { get; set; } = string.Empty;

        public List<WishedBook> Wishlist { get; set; } = new List<WishedBook>();
        public List<CartBook> Cart { get; set; } = new List<CartBook>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
