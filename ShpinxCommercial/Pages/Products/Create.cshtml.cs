using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using ShpinxCommercial.Data;

namespace ShpinxCommercial.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ShpinxCommercial.Data.ShpinxCommercialDbContext _context;

        // injecting the db context
        public CreateModel(ShpinxCommercial.Data.ShpinxCommercialDbContext context)
        {
            _context = context;
        }

        // method executed on get requests
        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientEmail");
            return Page();
        }

        // bind property to pass model to the razor page
        [BindProperty]
        public Product Product { get; set; } = default!;

        // method executed on POST requests
        public async Task<IActionResult> OnPostAsync()
        {

            // Use entity Framework ORM to add Product object
            _context.Products.Add(Product);

            // save changes to database 
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
