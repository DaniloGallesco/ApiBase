using ClubeAss.Domain.Commands;
using MediatR;
using System;

namespace ClubeAss.API.Customer.ViewModel.Customer
{
    public class CustomerUpdateRequestViewModel
    {
        public string Nome { get; set; }
    }
}