using System;
using AutoMapper;
using HelloWebApi.BookOperations.GetBooksQueryDetail;
using static HelloWebApi.BookOperations.CreateBook.CreateBooksCommand;

namespace HelloWebApi.Commen
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt=> opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
