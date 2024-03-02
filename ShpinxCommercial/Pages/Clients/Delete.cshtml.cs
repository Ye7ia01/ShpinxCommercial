using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using ShpinxCommercial.Data;

namespace ShpinxCommercial.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly ShpinxCommercial.Data.ShpinxCommercialDbContext _context;

        public DeleteModel(ShpinxCommercial.Data.ShpinxCommercialDbContext context)
        {
            _context = context;
        }
        // bind property to pass the model to the razor page
        [BindProperty]
        public Client Client { get; set; } = default!;

        // method executed on GET requests to this endpoint
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // LINQ to return client object that matches the ID in the query string 
            var client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }
            else
            {
                Client = client;
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

            // returns client object that matches id given in the query string
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                Client = client;
                // entity framework orm to remove the object
                _context.Clients.Remove(Client);
                // save changes to the DB
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
