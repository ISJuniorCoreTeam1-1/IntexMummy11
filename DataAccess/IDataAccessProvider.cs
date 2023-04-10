using IntexMummy11.Models;
using System.Collections.Generic;

namespace IntexMummy11.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddUserRecord(User user);
        void UpdateUserRecord(User user);
        void DeleteUserRecord(string username);
        User GetUserSingleRecord(string username);
        List<User> GetUserRecords();
    }
}