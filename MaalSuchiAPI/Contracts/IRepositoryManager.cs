namespace MaalSuchiAPI.Contracts
{
    public interface IRepositoryManager
    {
        IStoreRepository Store { get; }
        IVendorRepository Vendor { get; }
        void Save();
    }
}
