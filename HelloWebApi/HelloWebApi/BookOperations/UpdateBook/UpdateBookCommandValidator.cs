using System;
using FluentValidation;

namespace HelloWebApi.BookOperations.UpdateBook
{
	public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
	{
		public UpdateBookCommandValidator()
		{
            //RuleFor(command => command.Model.Title).MinimumLength(0);
            //RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.BookId).GreaterThan(0);
        }
	}
}

