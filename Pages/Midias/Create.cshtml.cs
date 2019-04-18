using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD.Models;
using System.IO;
using System.Data.SqlClient;

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
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=CRUDContext-d12658e6-afaa-4d40-b3b4-93eaf9df42d9;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

            }

            var name = Request.Form["Midia.Name"];
            var path = Request.Form["Midia.Data"];
            var fullPath = System.IO.Path.GetFullPath(path);
            var file = System.IO.File.ReadAllBytes(fullPath);

            Midia.Name = name;
            Midia.Data = file;

            _context.Midia.Add(Midia);
            await _context.SaveChangesAsync();

            TryValidateModel(Midia);
            return RedirectToPage("./Index");

            if (ModelState.IsValid)
            {
            }

            return Page();
        }
    }
}