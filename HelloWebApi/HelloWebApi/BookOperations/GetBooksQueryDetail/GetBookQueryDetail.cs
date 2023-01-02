using System;
using System.Linq;
using AutoMapper;
using HelloWebApi.Commen;
using HelloWebApi.DbOperations;

namespace HelloWebApi.BookOperations.GetBooksQueryDetail
{
    public class GetBookQueryDetail
    {
        private readonly BookStoreDbContext _dbContext;
        public BookDetailViewModel Model;
        private readonly IMapper _mapper;

        public int BookId { get; set; }

        public GetBookQueryDetail(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if(book == null)
            {
                throw new InvalidOperationException("kitap bulunamadı");
            }
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Id = book.Id;
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.ToString("dd/MM/yyyy");
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }
        
    }
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
