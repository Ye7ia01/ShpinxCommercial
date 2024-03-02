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
    public class IndexModel : PageModel
    {
        private readonly ShpinxCommercial.Data.ShpinxCommercialDbContext _context;

        // dependency injections
        public IndexModel(ShpinxCommercial.Data.ShpinxCommercialDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        // method executed on GET requests to the endpoint
        public async Task OnGetAsync()
        {
            // LINQ to get List of all products & "Include" is used to get the correspoinding Client object
            Product = await _context.Products
                .Include(p => p.Client).ToListAsync();
        }
    }
}
