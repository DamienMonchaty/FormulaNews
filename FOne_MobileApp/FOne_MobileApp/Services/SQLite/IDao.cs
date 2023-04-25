using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FOne_MobileApp.Services.SQLite
{
    public interface IDao<T>
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetFirst();
    }
}
