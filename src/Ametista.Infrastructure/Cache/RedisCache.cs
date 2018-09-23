using Ametista.Core;
using Ametista.Core.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Cache
{
    public class RedisCache : ICache
    {
        private readonly ConnectionMultiplexer redis;
        private readonly IDatabase db;
        public RedisCache(AmetistaConfiguration configuration)
        {
            redis = ConnectionMultiplexer.Connect(configuration.ConnectionStrings.RedisCache);
            db = redis.GetDatabase();
        }

        public async Task Delete(string key)
        {
            await db.KeyDeleteAsync(key);
        }

        public async Task<T> Get<T>(string key)
        {
            var value = await db.StringGetAsync(key);

            if (!value.HasValue)
            {
                return default(T);
            }

            var result = JsonConvert.DeserializeObject<T>(value);

            return await Task.FromResult(result);
        }

        public async Task Store<T>(string key, T value, params string[] @params)
        {
            var complexKey = GenerateKeyWithParams(key, @params);
            var cache = JsonConvert.SerializeObject(value);

            await db.StringSetAsync(complexKey, cache);
        }

        private string GenerateKeyWithParams(string key, string[] @params)
        {
            if (@params == null)
            {
                return key;
            }

            var complexKey = key;

            foreach (var param in @params)
            {
                complexKey += $"&{param}";
            }

            return complexKey;
        }
    }
}
