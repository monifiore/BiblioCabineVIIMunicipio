using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Interface
{
    public interface ISessionRepository
    {
        Task<T> GetSession<T>(string key) where T : class;
        Task SetSession<T>(string key, T value) where T : class;
        Task DeleteSession(string key);
    }
}