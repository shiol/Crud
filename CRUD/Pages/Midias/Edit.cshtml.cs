using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Pages.Midias
{
    public class EditModel : PageModel
    {
        private readonly CRUD.Models.CRUDContext _context;

        public EditModel(CRUD.Models.CRUDContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Midia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MidiaExists(Midia.MidiaId))
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

        private bool MidiaExists(int id)
        {
            return _context.Midia.Any(e => e.MidiaId == id);
        }
    }
}
