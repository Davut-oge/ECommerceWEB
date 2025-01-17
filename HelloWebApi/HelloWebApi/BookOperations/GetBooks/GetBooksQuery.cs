﻿using System;
using System.Collections.Generic;
using System.Linq;
using HelloWebApi.Commen;
using HelloWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HelloWebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = new List <BooksViewModel>();
            foreach(var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount

                });
            }
            return vm; 
        }
    }
    public class BooksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        
    }
}
