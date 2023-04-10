using IntexMummy11.Models;
using System.Collections.Generic;
using System.Linq;

namespace IntexMummy11.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddPatientRecord(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdatePatientRecord(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeletePatientRecord(string username)
        {
            var entity = _context.Users.FirstOrDefault(t => t.username == username);
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public User GetPatientSingleRecord(string username)
        {
            return _context.Users.FirstOrDefault(t => t.username == username);
        }

        public List<User> GetPatientRecords()
        {
            return _context.Users.ToList();
        }

        public void AddUserRecord(User user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserRecord(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUserRecord(string username)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserSingleRecord(string username)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetUserRecords()
        {
            throw new System.NotImplementedException();
        }
    }
}