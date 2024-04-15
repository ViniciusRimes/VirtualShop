using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context;
using VirtualShop.ProductApi.Repositories;

namespace APICatalog.Repositories
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private IProductRepository? _productRepository;
        private ICategoryRepository? _categoryRepository;
        private AppDBContext _context;
        private UnityOfWork _unityOfWork;

        public UnityOfWork(AppDBContext context, UnityOfWork unityOfWork)
        {

            _context = context;
            _unityOfWork = unityOfWork;
        }
        public IProductRepository ProductRepository { get { return _productRepository = _productRepository ?? new ProductRepository(_context, _unityOfWork); } }
        public ICategoryRepository CategoryRepository { get { return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context, _unityOfWork); } }


        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    await entry.ReloadAsync();
                }

                // Após recarregar os dados, tente salvar as alterações novamente
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
