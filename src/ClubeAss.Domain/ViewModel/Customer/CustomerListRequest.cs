using ClubeAss.API.Customer.ViewModel.Customer;
using MediatR;
using System.Collections.Generic;

namespace ClubeAss.Domain.Commands
{
    public class CustomerListRequest : IRequest<IEnumerable<CustomerResponse>>
    {
    }
}
