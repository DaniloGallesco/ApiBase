using MediatR;

namespace ClubeAss.Domain.Commands
{
    public class CustomerListRequest : IRequest<BaseResponse>
    {        
        public int? page { get; set; }
    }
}
