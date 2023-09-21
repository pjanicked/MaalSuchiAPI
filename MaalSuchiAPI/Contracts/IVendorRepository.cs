using MaalSuchiAPI.Models;

namespace MaalSuchiAPI.Contracts
{
    public interface IVendorRepository
    {
        IEnumerable<Vendor> GetAllVendors(bool trackChanges);

        Task SaveVendor(Vendor item);

        void UpdateVendor(Guid Id, Vendor item);

        void DeleteVendor(Guid Id, Vendor item);
    }
}
