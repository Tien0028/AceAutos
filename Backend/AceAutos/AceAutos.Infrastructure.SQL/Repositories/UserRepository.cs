using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _ctx.Users.Add(newUser);
            _ctx.SaveChanges();
        }

        public User DeleteUser(int id)
        {
            var user = _ctx.Users.FirstOrDefault(c => c.Id == id);
            _ctx.Entry(user).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return user;
        }

        public User Edit(User updateUser)
        {
            _ctx.Entry(updateUser).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updateUser;
        }

        public User Edit(int id, User updateUser)
        {
            var selectedUser = GetUserById(id);
            if (selectedUser != null)
            {
                selectedUser.Username = updateUser.Username;
                selectedUser.IsAdmin = updateUser.IsAdmin;
                _ctx.Entry(selectedUser).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            return updateUser;
        }

        public User Get(long id)
        {
            return _ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _ctx.Users.ToList();
        }

        public List<User> GetAllUsers()
        {
            return _ctx.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _ctx.Users.FirstOrDefault(user => user.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _ctx.Users.ToList().FirstOrDefault(u => u.Username == username);
        }

        public void Remove(long id)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Id == id);
            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
        }

    }
}
