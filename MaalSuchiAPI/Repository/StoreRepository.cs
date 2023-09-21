using MaalSuchiAPI.Contracts;
using MaalSuchiAPI.Models;

namespace MaalSuchiAPI.Repository
{
    public class StoreRepository : RepositoryBase<StoreItem>, IStoreRepository
    {
        public StoreRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<StoreItem> GetAllStoreItems(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(c => c.Name)
           .ToList();

        public async Task SaveStoreItem(StoreItem item) =>
            await Create(item);

        public void UpdateStoreItem(Guid Id, StoreItem item)
        {
            var storeItem = FindByCondition(x => x.Id == Id, false);
            if (storeItem == null)
                throw new Exception("Not Found");

            item.Id = Id;
            Update(item);
        }

        public void DeleteStoreItem(Guid Id, StoreItem item)
        {
            var storeItem = FindByCondition(x => x.Id == Id, false);
            if (storeItem == null)
                throw new Exception("Not Found");

            item.Id = Id;
            Delete(item);
        }
    }
}
