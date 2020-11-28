using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Infrastructure.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _ctx;

        public UserRepository(DBContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(User newUser)
        {
            throw new NotImplementedException();
        }

        public void Edit(User updateUser)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }
    }
}
