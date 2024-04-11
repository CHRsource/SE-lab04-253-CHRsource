using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAudios.Data;
using RazorPagesAudios.Models;

namespace RazorPagesAudios.Pages.Audios
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesAudios.Data.RazorPagesAudiosContext _context;

        public CreateModel(RazorPagesAudios.Data.RazorPagesAudiosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Audio Audio { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Audio == null || Audio == null)
            {
                return Page();
            }

            _context.Audio.Add(Audio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
