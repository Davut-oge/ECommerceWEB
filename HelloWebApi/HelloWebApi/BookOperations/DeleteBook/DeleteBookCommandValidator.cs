using System;
using FluentValidation;

namespace HelloWebApi.BookOperations.DeleteBook
{
	public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
	{
		public DeleteBookCommandValidator()
		{
			RuleFor(command => command.BookId).GreaterThan(0);
		}
	}
}

