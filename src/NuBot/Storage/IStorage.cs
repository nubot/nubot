using System;
using System.Threading;
using System.Threading.Tasks;

namespace NuBot.Storage
{
    public interface IStorage
    {
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken);

        Task SetAsync(string key, object value, CancellationToken cancellationToken);
    }
}
