using Microsoft.Extensions.Configuration;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CRUDAPI.Infra
{
    public abstract class AbstractRepository<TEntity, TKey>
        where TEntity : class
    {
       
       //protected string StringConnection = ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;

        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(TKey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract void DeleteById(TKey id);
    }
}
