using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD.Models;

namespace CRUD.Pages.Midias
{
    public class CreateModel : PageModel
    {
        private readonly CRUD.Models.CRUDContext _context;

        public CreateModel(CRUD.Models.CRUDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Midia Midia { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Midia = new Midia(Midia);
            _context.Midia.Add(Midia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}