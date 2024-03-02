using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using ShpinxCommercial.Data;

namespace ShpinxCommercial.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly ShpinxCommercial.Data.ShpinxCommercialDbContext _context;

        // injecting the dbcontext 
        public CreateModel(ShpinxCommercial.Data.ShpinxCommercialDbContext context)
        {
            _context = context;
        }

        // Method executed on get requets to this endpoint
        public IActionResult OnGet()
        {
            return Page();
        }

        // bind property to pass model to the razor page
        [BindProperty]
        public Client Client { get; set; } = default!;

        // method executed on POST requests
        public async Task<IActionResult> OnPostAsync()
        {
            // validate model 
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Use entity Framework ORM to add client object
            _context.Clients.Add(Client);
            // save database changes 
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
