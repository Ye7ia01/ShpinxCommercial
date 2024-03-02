using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using ShpinxCommercial.Data;

namespace ShpinxCommercial.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly ShpinxCommercial.Data.ShpinxCommercialDbContext _context;

        public EditModel(ShpinxCommercial.Data.ShpinxCommercialDbContext context)
        {
            _context = context;
        }

        // bind property to pass model to the razor page
        [BindProperty]
        public Client Client { get; set; } = default!;

        // method executed on GET requests to the endpoint
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // return client object matches the id given in the query string
            var client =  await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            Client = client;
            return Page();
        }

        // method executed on POST requests to this endpoint
        public async Task<IActionResult> OnPostAsync()
        {
            // model validation
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // could be implemented by getting the object then using the "Update() method also"
            _context.Attach(Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(Client.ClientId))
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

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
