using Flight_backend.Models;
using Flight_backend.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Flight_backend.Controllers;
using Flight_backend.Repository;
using Flight_backend.Models;


namespace Flight_backend.Repository
{
    public class UserRepository : IDataRepository<Customer>
    {
        private readonly RegisterDBEntities _RegisterDBContext;

        // Constructor Dependency Injection
        public UserRepository(RegisterDBEntities registerDBContext)
        {
            _RegisterDBContext = registerDBContext;
        }

        public void Add(Customer newUser)
        {
            _RegisterDBContext.Customers.Add(newUser);
            _RegisterDBContext.SaveChanges();
        }

        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer dbEntity)
        {
            throw new NotImplementedException();
        }

        /*
        public void Delete(int userId)
        {
            User user = _bookDBContext.Users.Find(userId);
            _bookDBContext.Users.Remove(user);
            _bookDBContext.SaveChanges();
        }

        public User Get(int id)
        {
            return _bookDBContext.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _bookDBContext.Users.ToList();
        }

        public void Update(User updateUser)
        {
            _bookDBContext.Entry(updateUser).State = EntityState.Modified;
            _bookDBContext.SaveChanges();
        }
        */
    }
}
