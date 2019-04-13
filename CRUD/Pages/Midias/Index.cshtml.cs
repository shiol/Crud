using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Pages.Midias
{
    public class IndexModel : PageModel
    {
        private readonly CRUD.Models.CRUDContext _context;

        public IndexModel(CRUD.Models.CRUDContext context)
        {
            _context = context;
        }

        public IList<Midia> Midia { get;set; }

        public async Task OnGetAsync()
        {
            Midia = await _context.Midia.ToListAsync();
        }
    }
}
