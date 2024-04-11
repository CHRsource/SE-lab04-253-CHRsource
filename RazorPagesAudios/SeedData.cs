using Microsoft.EntityFrameworkCore;
using RazorPagesAudios.Data;

namespace RazorPagesAudios.Models;

public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using (var context = new RazorPagesAudiosContext(
			serviceProvider.GetRequiredService<
				DbContextOptions<RazorPagesAudiosContext>>()))
		{
			if (context == null || context.Audio == null)
			{
				throw new ArgumentNullException("Null RazorPagesAudiosContext");
			}

			// Look for any movies.
			if (context.Audio.Any())
			{
				return;   // DB has been seeded
			}

			context.Audio.AddRange(
				new Audio
				{
					Title = "Thriller",
					Performer = "Michael Jackson",
					ReleaseDate = DateTime.Parse("1982-2-12"),
					Genre = "Pop",
					TracksNumbers = 12,
					TotalDuration = TimeSpan.Parse("1:01:13"),
					Price = 9.99M,
					Rating = "R"
				},

				new Audio
				{
					Title = "Back in Black",
					Performer = "AC/DC",
					ReleaseDate = DateTime.Parse("1980-9-23"),
					Genre = "Rock",
					TracksNumbers = 5,
					TotalDuration = TimeSpan.Parse("0:23:53"),
					Price = 7.99M,
                    Rating = "R"
                },

				new Audio
				{
					Title = "21",
					Performer = "Adele",
					ReleaseDate = DateTime.Parse("2011-12-30"),
					Genre = "Pop",
					TracksNumbers = 15,
					TotalDuration = TimeSpan.Parse("1:12:45"),
					Price = 8.99M,
                    Rating = "R"
                },

				new Audio
				{
					Title = "Utopia",
					Performer = "Travis Scott",
					ReleaseDate = DateTime.Parse("2023-01-01"),
					Genre = "Rap",
					TracksNumbers = 8,
					TotalDuration = TimeSpan.Parse("0:41:32"),
					Price = 10.99M,
                    Rating = "R"
                }
			);
			context.SaveChanges();
		}
	}
}