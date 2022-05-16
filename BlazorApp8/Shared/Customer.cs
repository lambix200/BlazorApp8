using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp8.Shared
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Email { get; set; }
        public int? age { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? Telephone { get; set; }

        public IEnumerable<Product>? Products { get; set; }
    }
}
