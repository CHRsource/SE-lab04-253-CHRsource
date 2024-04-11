using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudios.Data;
using RazorPagesAudios.Models;

namespace RazorPagesAudios.Pages.Audios
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesAudios.Data.RazorPagesAudiosContext _context;

        public DetailsModel(RazorPagesAudios.Data.RazorPagesAudiosContext context)
        {
            _context = context;
        }

      public Audio Audio { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Audio == null)
            {
                return NotFound();
            }

            var audio = await _context.Audio.FirstOrDefaultAsync(m => m.Id == id);
            if (audio == null)
            {
                return NotFound();
            }
            else 
            {
                Audio = audio;
            }
            return Page();
        }
    }
}
