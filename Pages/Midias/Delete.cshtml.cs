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
    public class DeleteModel : PageModel
    {
        private readonly CRUD.Models.CRUDContext _context;

        public DeleteModel(CRUD.Models.CRUDContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Midia = await _context.Midia.FindAsync(id);

            if (Midia != null)
            {
                _context.Midia.Remove(Midia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
