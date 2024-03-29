﻿using ClubeAss.API.Customer.ViewModel.Customer;
using ClubeAss.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClubeAss.API.Customer.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> List([FromQuery] CustomerListRequest list)
        {
            var response = await _mediator.Send(list);

            return StatusCode(response.StatusCode.GetHashCode(), response);
        }

        // POST api/<ClienteController>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Post([FromBody] CustomerAddRequest cliente)
        {
            var response = await _mediator.Send(cliente);

            return StatusCode(response.StatusCode.GetHashCode(), response);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _mediator.Send(new CustomerGetRequest(id));

            return StatusCode(response.StatusCode.GetHashCode(), response);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new CustomerGetRequest(Guid.NewGuid()));

            return StatusCode(response.StatusCode.GetHashCode(), response);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CustomerUpdateRequestViewModel request)
        {

            var response = await _mediator.Send(new CustomerUpdateRequest() { Id = id, Nome = request.Nome });

            return StatusCode(response.StatusCode.GetHashCode(), response);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new CustomerDeleteRequest(id));

            return StatusCode(response.StatusCode.GetHashCode(), response);
        }
    }
}