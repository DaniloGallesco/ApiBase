using ClubeAss.Domain.Commands;
using MediatR;
using System;

namespace ClubeAss.API.Customer.ViewModel.Customer
{
    public class CustomerUpdateRequest : IRequest<BaseResponse>
    {


        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}