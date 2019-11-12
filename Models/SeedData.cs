using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Singles Ward",
                        ReleaseDate = DateTime.Parse("2002-9-1"),
                        Genre = "Romantic Comedy",
                        Rating = "PG",
                        Price = 19.75M
                    },

                    new Movie
                    {
                        Title = "The Best Two Years",
                        ReleaseDate = DateTime.Parse("2004-9-7"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 32.75M
                    },

                    new Movie
                    {
                        Title = "The Errand of Angels",
                        ReleaseDate = DateTime.Parse("2008-2-23"),
                        Genre = "Drama",
                        Rating = "PG",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Midway To Heaven",
                        ReleaseDate = DateTime.Parse("2011-4-15"),
                        Genre = "Romantic Comedy",
                        Rating = "PG",
                        Price = 12.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}