using CRUDAPI.Domain;
using CRUDAPI.Infra;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CRUDAPI.Service
{
    public class PessoaService 
    {
        PessoaRepository repository;
        private readonly IConfiguration _configuration;
        public PessoaService(IConfiguration configuration)
        {
            _configuration = configuration;
            repository = new PessoaRepository(_configuration);
        }
       
        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }
        public List<Pessoa> GetAll()
        {
            return repository.GetAll();
        }
        public Pessoa GetById(int id)
        {
            return repository.GetById(id);
        }
        public void Save(Pessoa entity)
        {
            repository.Save(entity);
        }
        public void Update(Pessoa entity)
        {
            repository.Update(entity);
        }

    }
}
