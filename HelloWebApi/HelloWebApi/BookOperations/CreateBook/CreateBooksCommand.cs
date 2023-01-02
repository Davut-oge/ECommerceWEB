using System;
using System.Linq;
using AutoMapper;
using HelloWebApi.DbOperations;

namespace HelloWebApi.BookOperations.CreateBook
{
    public class CreateBooksCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBooksCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext  = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book != null)
                throw new InvalidOperationException("Kitap zaten mevcut");
            
                book = new Book();
                book.Title = Model.Title;
                book.PageCount = Model.PageCount;
                book.PublishDate = Model.PublishDate;
                book.GenreId = Model.GenreId;

                
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
        
    }
}
