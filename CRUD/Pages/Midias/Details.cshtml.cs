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
    public class DetailsModel : PageModel
    {
        private readonly CRUD.Models.CRUDContext _context;

        public DetailsModel(CRUD.Models.CRUDContext context)
        {
            _context = context;
        }

        public Midia Midia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Midia = await _context.Midia.FirstOrDefaultAsync(m => m.MidiaId == id);

            if (Midia == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
