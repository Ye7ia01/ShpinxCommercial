using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json.Serialization;
using ShpinxCommercial.Data;

namespace ShpinxCommercial.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ShpinxCommercial.Data.ShpinxCommercialDbContext _context;


        // DB context injection
        public EditModel(ShpinxCommercial.Data.ShpinxCommercialDbContext context)
        {
            _context = context;
        }

        // bind property to pass model to razor page
        [BindProperty]
        public Product Product { get; set; } = default!;

        // method executed on GET requests to the endpoint
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Linq to return Product objects that matches id given in query string
            var product =  await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            // set view data to be accesed by razor page 
           ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientEmail");
            return Page();
        }


        // method executed on POST requests
        public async Task<IActionResult> OnPostAsync()
        {
            // model validation
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // could be impleented by the "Update() method"
            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
