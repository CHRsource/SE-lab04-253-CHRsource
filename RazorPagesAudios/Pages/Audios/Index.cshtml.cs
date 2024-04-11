using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudios.Data;
using RazorPagesAudios.Models;

namespace RazorPagesAudios.Pages.Audios
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAudios.Data.RazorPagesAudiosContext _context;

        public IndexModel(RazorPagesAudios.Data.RazorPagesAudiosContext context)
        {
            _context = context;
        }

        public IList<Audio> Audio { get;set; } = default!;


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AudioGenre { get; set; }


        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from a in _context.Audio
                                            orderby a.Genre
                                            select a.Genre;

            var audios = from a in _context.Audio
                         select a;

            if (!string.IsNullOrEmpty(SearchString))
            {
                audios = audios.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(AudioGenre))
            {
                audios = audios.Where(x => x.Genre == AudioGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Audio = await audios.ToListAsync();
        }
    }
}
