using LegartiWeb.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegartiWeb.Data
{
    public class SessionRepository: ISessionRepository
    {

        [Inject]
        public ProtectedSessionStorage _sessionStorage { set; get; }

        public SessionRepository(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task SetSession<T>(string key, T value) where T : class
        {
            string json = null;
            if (value != null)
                json = JsonSerializer.Serialize(value);
            await _sessionStorage.SetAsync(key, value);
        }

        public async Task<T> GetSession<T>(string key) where T : class
        {
            var result = await _sessionStorage.GetAsync<T>(key);

            return result.Value;
        }

        public async Task DeleteSession(string key)
        {
            await _sessionStorage.DeleteAsync(key);
        }
    }
}
