using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Models;
using ShpinxCommercial.Data;

namespace ShpinxCommercial.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly ShpinxCommercial.Data.ShpinxCommercialDbContext _context;

        // inject DBcontext 
        public IndexModel(ShpinxCommercial.Data.ShpinxCommercialDbContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // entity framework ORM to return a list of Client objects 

            Client = await _context.Clients.ToListAsync();
        }
    }
}
