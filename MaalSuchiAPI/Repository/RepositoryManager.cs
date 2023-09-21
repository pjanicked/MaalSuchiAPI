using MaalSuchiAPI.Contracts;

namespace MaalSuchiAPI.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IStoreRepository? _storeRepository;
        private IVendorRepository? _vendorRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IStoreRepository Store
        {
            get
            {
                if (_storeRepository == null)
                    _storeRepository = new StoreRepository(_repositoryContext);

                return _storeRepository;
            }
        }

        public IVendorRepository Vendor
        {
            get
            {
                if (_vendorRepository == null)
                    _vendorRepository = new VendorRepository(_repositoryContext);

                return _vendorRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
