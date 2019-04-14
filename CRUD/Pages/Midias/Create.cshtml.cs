using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using CRUD.Utilities;

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
        [BindProperty]
        public IFormFile File { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var publicScheduleData =
               await FileHelpers.ProcessFormFile(FileUpload.UploadPublicSchedule, ModelState);

            var privateScheduleData =
  await FileHelpers.ProcessFormFile(FileUpload.UploadPrivateSchedule, ModelState);

            var filePath = Path.GetTempFileName();

            if (File.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            var data = (new { count = File.Count, size, filePath });

            _context.Midia.Add(Midia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}