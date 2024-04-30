using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookInventory.Data;
using BookInventory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookInventory.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookInventory.Data.BookInventoryContext _context;

        public IndexModel(BookInventory.Data.BookInventoryContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from b in _context.Book
                                            orderby b.Genre
                                            select b.Genre;
            var books = from b in _context.Book
                         select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(BookGenre))
            {
                books = books.Where(x => x.Genre == BookGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
            //Book = await _context.Book.ToListAsync();
        }
    }
}
