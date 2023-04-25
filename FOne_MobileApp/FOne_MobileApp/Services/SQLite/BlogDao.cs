using FOne_MobileApp.Models;
using FOne_MobileApp.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FOne_MobileApp.Services.SQLite
{
    public class BlogDao : IDao<Blog>
    {
        private SQLiteAsyncConnection _connection;

        public BlogDao(ISQLiteDb db)
        {
            _connection = db.GetConnection();
        }

        public async Task<Blog> GetFirst()
        {
            return await _connection.Table<Blog>().FirstAsync();
        }

        public async Task<IEnumerable<Blog>> GetListAsync()
        {
            return await _connection.Table<Blog>().ToListAsync();
        }

    }
}
