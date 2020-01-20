using System.Collections.Generic;

namespace Interview.Infrastructure.Contracts
{
    public interface IJsonOperationService
    {
        IEnumerable<T> LoadJsonFile<T>();
        void UpdateJsonFile<T>(List<T> orders);
    }
}