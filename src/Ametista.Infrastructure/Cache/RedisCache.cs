using Ametista.Core;
using Ametista.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Cache
{
    public class RedisCache : ICache
    {
        private readonly ConnectionMultiplexer redis;
        private readonly IDatabase db;
        private readonly ILogger<RedisCache> _logger;

        public RedisCache(AmetistaConfiguration configuration, ILogger<RedisCache> logger)
        {
            redis = ConnectionMultiplexer.Connect(configuration.ConnectionStrings.RedisCache);
            db = redis.GetDatabase();
            _logger = logger;
        }

        public async Task<bool> Delete(string key)
        {
            try
            {
                foreach (var ep in redis.GetEndPoints())
                {
                    var server = redis.GetServer(ep);
                    var keys = server.Keys(database: 0, pattern: key + "*").ToArray();
                    await db.KeyDeleteAsync(keys);
                }
                
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro when deleting redis cache key");

                throw;
            }
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
