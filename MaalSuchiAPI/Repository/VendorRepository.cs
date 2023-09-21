using MaalSuchiAPI.Contracts;
using MaalSuchiAPI.Models;

namespace MaalSuchiAPI.Repository
{
    public class VendorRepository : RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Vendor> GetAllVendors(bool trackChanges) => 
            FindAll(trackChanges)
           .OrderBy(c => c.Name)
           .ToList();

        public async Task SaveVendor(Vendor item) =>
            await Create(item); 

        public void UpdateVendor(Guid Id, Vendor item)
        {
            var vendor = FindByCondition(x => x.Id == Id, false);
            if (vendor == null)
                throw new Exception("Not Found");

            item.Id = Id;
            Update(item);
        }

        public void DeleteVendor(Guid Id, Vendor item)
        {
            var vendor = FindByCondition(x => x.Id == Id, false);
            if (vendor == null)
                throw new Exception("Not Found");

            item.Id = Id;
            Delete(item);
        }
    }
}
