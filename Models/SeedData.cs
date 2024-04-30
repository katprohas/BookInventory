using BookInventory.Data;
using Microsoft.EntityFrameworkCore;
namespace BookInventory.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookInventoryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookInventoryContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Stardust",
                        Author = "Neil Gaiman",
                        PublishDate = DateTime.Parse("1999-02-01"),
                        Genre = "Fantasy",
                        Isbn = 9780061142024
                    },

                    new Book
                    {
                        Title = "The Mask of Mirrors",
                        Author = "M.A. Carrick",
                        PublishDate = DateTime.Parse("2021-01-19"),
                        Genre = "Fantasy",
                        Isbn = 9780356515175
                    },

                     new Book
                     {
                         Title = "The Black Arrow",
                         Author = "Robert Louis Stevenson",
                         PublishDate = DateTime.Parse("1883-01-02"),
                         Genre = "Historical Fiction",
                         Isbn = 9780543896605
                     },
                     new Book
                     {
                         Title = "When Women Were Dragons",
                         Author = "Kelly Barnhill",
                         PublishDate = DateTime.Parse("2023-05-03"),
                         Genre = "Fantasy",
                         Isbn = 9780385548229
                     },
                    new Book
                    {
                        Title = "Timeline",
                        Author = "Michael Crichton",
                        PublishDate = DateTime.Parse("1999-11-16"),
                        Genre = "Science Fiction",
                        Isbn = 9780099244721
                    }
                );
                context.SaveChanges();
            }
        }
    }
}