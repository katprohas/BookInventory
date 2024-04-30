using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookInventory.Models;

namespace BookInventory.Data
{
    public class BookInventoryContext : DbContext
    {
        public BookInventoryContext (DbContextOptions<BookInventoryContext> options)
            : base(options)
        {
        }

        public DbSet<BookInventory.Models.Book> Book { get; set; } = default!;
    }
}
