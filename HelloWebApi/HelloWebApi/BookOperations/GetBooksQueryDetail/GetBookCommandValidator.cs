using System;
using FluentValidation;

namespace HelloWebApi.BookOperations.GetBooksQueryDetail
{
	public class GetBookCommandValidator : AbstractValidator <GetBookQueryDetail>
	{
		public GetBookCommandValidator()
		{
            RuleFor(command => command.Model.Id).GreaterThan(0);

        }
    }
}

