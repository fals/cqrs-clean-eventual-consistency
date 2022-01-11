using Ametista.Core.Interfaces;
using System.Threading.Tasks;

namespace Ametista.UnitTest.Fakes
{
    internal class FakeCache : ICache
    {
        public Task<bool> Delete(string key)
        {
            return Task.FromResult(true);
        }

        public Task<T> Get<T>(string key)
        {
            return null;
        }

        public Task Store<T>(string key, T value, params string[] @params)
        {
            return Task.CompletedTask;
        }
    }
}
