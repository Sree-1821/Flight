using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_backend.Controllers;
using Flight_backend.Models;
using Flight_backend.Repository;

namespace Flight_backend.Repository
{
    internal interface IDataRepository<TEntity>
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Update(TEntity dbEntity);
        void Delete(int entity);
    }



}
