using ClubeAss.Domain.Commands;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ClubeAss.Domain.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
             where TRequest : IRequest<TResponse> where TResponse : BaseResponse
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }


        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new BaseResponse(HttpStatusCode.BadRequest, failures.Select(p => p.ErrorMessage));

            return Task.FromResult(response as TResponse);
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
               .Select(v => v.Validate(request))
               .SelectMany(result => result.Errors)
               .Where(f => f != null)
               .ToList();

            return failures.Any()
                     ? Errors(failures)
                     : next();
        }
    }
}
