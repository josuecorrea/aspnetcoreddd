namespace Project.Accounting.Service.Domain.Contracts.Services
{
    public interface ICacheService
    {
        Task SetValue(string key, string value, TimeSpan expireAt);
        Task<T> GetValue<T>(string key) where T : class;
        Task SetHashValue(string key, string hashEntryKey, string value, TimeSpan expireAt);
        Task<IEnumerable<KeyValuePair<string, string>>> GetHashValue(string key);
        Task DeleteHash(string key, string hashField);
        Task DeleteKey(string key);
    }
}
