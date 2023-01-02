using System;
using HelloWebApi.DbOperations;

namespace HelloWebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
                
        }
    }
}
