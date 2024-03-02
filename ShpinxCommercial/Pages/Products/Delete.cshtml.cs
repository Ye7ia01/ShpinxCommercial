using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using ShpinxCommercial.Data;

namespace ShpinxCommercial.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ShpinxCommercial.Data.ShpinxCommercialDbContext _context;

        // inject Db context
        public DeleteModel(ShpinxCommercial.Data.ShpinxCommercialDbContext context)
        {
            _context = context;
        }

        // bind property to pass model to the razor papge
        [BindProperty]
        public Product Product { get; set; } = default!;

        // method executed on GET requests
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // LINQ to return Product Object matches ID in query string
            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        // method executed on POST requests to the endpoint
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                Product = product;
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
