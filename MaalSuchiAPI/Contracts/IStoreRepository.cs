using MaalSuchiAPI.Models;

namespace MaalSuchiAPI.Contracts
{
    public interface IStoreRepository
    {
        IEnumerable<StoreItem> GetAllStoreItems(bool trackChanges);

        Task SaveStoreItem(StoreItem item);

        void UpdateStoreItem(Guid Id, StoreItem item);

        void DeleteStoreItem(Guid Id, StoreItem item);
    }
}
