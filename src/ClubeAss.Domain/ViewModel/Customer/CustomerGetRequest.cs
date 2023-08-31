using ClubeAss.Domain.Commands;
using MediatR;
using System;

namespace ClubeAss.API.Customer.ViewModel.Customer
{
    public class CustomerGetRequest : IRequest<BaseResponse>
    {
        public CustomerGetRequest(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
