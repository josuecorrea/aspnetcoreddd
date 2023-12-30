using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project.Accounting.Service.Domain.Contracts.Services;
using StackExchange.Redis;

namespace Project.Accounting.Service.Infra.Services
{
    public class CacheService : ICacheService
    {
        private readonly IConfiguration _configuration;

        private readonly IDatabase _db;

        public CacheService(IConfiguration configuration)
        {
            _configuration = configuration;

            var cnn = ConnectionMultiplexer.Connect(_configuration["ConnectionStrings:CacheConnection"]);
            _db = cnn.GetDatabase();
        }

        public async Task<T> GetValue<T>(string key) where T : class
        {
            var result = await _db.StringGetAsync(key);

            if (result.IsNull)
                return null;

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task SetValue(string key, string value, TimeSpan expireAt)
        {
            await _db.StringSetAsync(key, value, expireAt);
        }

        public async Task SetValue<T>(string key, T value, TimeSpan expireAt) where T : class
        {
            var json = JsonConvert.SerializeObject(value);

            await _db.StringSetAsync(key, json, expireAt);
        }

        public async Task SetHashValue(string key, string hashEntryKey, string value, TimeSpan expireAt)
        {
            await _db.HashSetAsync(key, new HashEntry[] { new HashEntry(new RedisValue($"{hashEntryKey}"), new RedisValue(value)) });
            await _db.KeyExpireAsync(key, expireAt);
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetHashValue(string key)
        {
            var result = await _db.HashGetAllAsync(key);

            var keyValuePairs = result.Select(c => new KeyValuePair<string, string>
                (c.Name.ToString(), c.Value.ToString())
            );

            return keyValuePairs;
        }

        public async Task DeleteHash(string key, string hashField)
        {
            await _db.HashDeleteAsync(key, hashField);
        }

        public async Task DeleteKey(string key)
        {
            await _db.KeyDeleteAsync(key);
        }
    }
}