﻿using ClubeAss.Domain;
using ClubeAss.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubeAss.Repository.Postegre
{
    public class CustomerRepository : ICustomerRepository
    {
        //private readonly IDbSession _session;

        //public CustomerRepository(IDbSession session)
        //{
        //    _session = session;
        //}

        //public async void Add(Customer customer)
        //{

        //    DynamicParameters parameter = new DynamicParameters();
        //    parameter.Add("@Nome", customer.Nome, DbType.String, ParameterDirection.Input);
        //    await _session.Connection.ExecuteAsync($"INSERT INTO public.\"Customer\" (\"Nome\") VALUES(@Nome)", parameter, _session.Transaction, null, CommandType.Text);

        //}

        //public async void Update(Customer customer)
        //{
        //    DynamicParameters parameter = new DynamicParameters();
        //    parameter.Add("@Id", customer.Id, DbType.Guid, ParameterDirection.Input);
        //    parameter.Add("@Nome", customer.Nome, DbType.String, ParameterDirection.Input);

        //    await _session.Connection.ExecuteAsync($"Update public.\"Customer\" set \"Nome\" = @Nome where \"Id\" = @id", parameter, _session.Transaction, null, CommandType.Text);

        //}

        //public Task<IEnumerable<Customer>> GetAll()
        //{
        //    return _session.Connection.QueryAsync<Customer>($"SELECT * FROM public.\"Customer\"", null, _session.Transaction, null, CommandType.Text);
        //}

        //public Task<Customer> GetById(Guid id)
        //{
        //    DynamicParameters parameter = new DynamicParameters();
        //    parameter.Add("@Id", id, DbType.Guid, ParameterDirection.Input);

        //    return _session.Connection.QueryFirstOrDefaultAsync<Customer>($"SELECT * FROM public.\"Customer\" where \"Id\" = @id", parameter, _session.Transaction, null, CommandType.Text);
        //}

        //public async void Remove(Guid id)
        //{

        //}

        //public void Remove(Customer customer)
        //{
        //    DynamicParameters parameter = new DynamicParameters();
        //    parameter.Add("@Id", customer.Id, DbType.Guid, ParameterDirection.Input);

        //    var a = _session.Connection.ExecuteAsync($"Delete FROM public.\"Customer\" where \"Id\" = @id", parameter, _session.Transaction, null, CommandType.Text).Result;

        //}
        public Task<Customer> AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}