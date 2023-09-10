using AutoMapper;
using ClubeAss.API.Customer.ViewModel.Customer;
using ClubeAss.Domain;
using ClubeAss.Domain.Commands;
using ClubeAss.Domain.Interface.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClubeAss.Application.CommandHandlers
{
    public class CustomerHandler : IRequestHandler<CustomerAddRequest, BaseResponse>,
                                   IRequestHandler<CustomerListRequest, BaseResponse>,
                                   IRequestHandler<CustomerGetRequest, BaseResponse>,
                                   IRequestHandler<CustomerDeleteRequest, BaseResponse>,
                                   IRequestHandler<CustomerUpdateRequest, BaseResponse>
    {
        private readonly ICustomerRepository _clienteRepositorio;
        private readonly ILogger<CustomerHandler> _log;
        private readonly IMapper _mapper;

        public CustomerHandler(ICustomerRepository clienteRepositorio, IMapper mapper, ILogger<CustomerHandler> log)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
            _log = log;
        }

        public async Task<BaseResponse> Handle(CustomerAddRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _mapper.Map<CustomerAddRequest, Customer>(request);

                await _clienteRepositorio.AddAsync(customer);

            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error add customer");
                throw;
            }

            return new BaseResponse(System.Net.HttpStatusCode.OK, null, new List<string>() { "Sucesso" });

        }

        public async Task<BaseResponse> Handle(CustomerListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _clienteRepositorio.GetAllAsync(request.page);

                if (!customers.Items.Any())
                {
                    return new BaseResponse(System.Net.HttpStatusCode.NoContent, null, new List<string>() { "Registro não localizado" });
                }

                return new BaseResponse(System.Net.HttpStatusCode.OK, customers, new List<string>() { "Sucesso" });

            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error GetAllAsync customer");
                throw;
            }
        }


        public async Task<BaseResponse> Handle(CustomerGetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _clienteRepositorio.GetByIdAsync(request.Id);

                if (customer == null)
                {
                    return new BaseResponse(System.Net.HttpStatusCode.BadRequest, null, new List<string>() { "Registro não localizado" });
                }

                return new BaseResponse(System.Net.HttpStatusCode.OK, customer, new List<string>() { "Sucesso" });
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error GET customer");
                throw;
            }
        }

        public async Task<BaseResponse> Handle(CustomerDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _clienteRepositorio.GetByIdAsync(request.Id);

                if (customers == null)
                {
                    return new BaseResponse(System.Net.HttpStatusCode.BadRequest, null, new List<string>() { "Registro não localizado" });
                }

                await _clienteRepositorio.DeleteAsync(customers);

            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error Delete customer");
                throw;
            }

            return new BaseResponse(System.Net.HttpStatusCode.OK, null, new List<string>() { "Sucesso" });

        }

        public async Task<BaseResponse> Handle(CustomerUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var customers = await _clienteRepositorio.GetByIdAsync(request.Id);

                if (customers == null)
                {
                    return new BaseResponse(System.Net.HttpStatusCode.BadRequest, null, new List<string>() { "Registro não localizado" });
                }

                var customer = _mapper.Map<CustomerUpdateRequest, Customer>(request);


                await _clienteRepositorio.UpdateAsync(customer);


                return new BaseResponse(System.Net.HttpStatusCode.OK, null, new List<string>() { "Sucesso" });
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error Update customer");
                throw;
            }
        }
    }
}