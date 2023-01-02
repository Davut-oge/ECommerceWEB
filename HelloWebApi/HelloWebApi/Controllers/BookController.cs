using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HelloWebApi.BookOperations.CreateBook;
using HelloWebApi.BookOperations.DeleteBook;
using HelloWebApi.BookOperations.GetBooks;
using HelloWebApi.BookOperations.GetBooksQueryDetail;
using HelloWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static HelloWebApi.BookOperations.CreateBook.CreateBooksCommand;

namespace HelloWebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

     
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /*private static List<Book> BookList = new List<Book>()
        {
            new Book{
                Id = 1,
                Title = "Lean startup",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime (2001,06,12)
            },
            new Book{
                Id = 2,
                Title = "Hearland",
                GenreId = 2,
                PageCount = 230,
                PublishDate = new DateTime (2010,03,11)
            },
              new Book{
                Id = 3,
                Title = "Dune",
                GenreId = 3,
                PageCount = 530,
                PublishDate = new DateTime (2014,12,11)
            }
        };*/

        [HttpGet]
        public IActionResult GetBook()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        } 

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookQueryDetail query = new GetBookQueryDetail(_context,_mapper);
                query.BookId = id;
                result = query.Handle();
               

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(result);
        }

        /*[HttpGet]
        public int BookCount()
        {
            int book = BookList.Count;
            return book;
        }
        */

        /*[HttpGet]
        public Book Get([FromQuery]string id)
        {
            var book = BookList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
        */

        //POST
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBooksCommand command = new CreateBooksCommand(_context,_mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                ValidationResult result = validator.Validate(command);
                validator.ValidateAndThrow(command);
                command.Handle();

                /*if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        Console.WriteLine("Özellik " + item.PropertyName + " Error Message: " + item.ErrorMessage);
                    }
                        
                }
                else
                    command.Handle();
                */
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }

        //PUT
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if(id == null)
            {
                return BadRequest();
            }
            else
            {
                
                return Ok();
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
