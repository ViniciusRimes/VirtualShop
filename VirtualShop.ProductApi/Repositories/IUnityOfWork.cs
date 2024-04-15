namespace VirtualShop.ProductApi.Repositories
{
    public interface IUnityOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task CommitAsync();
        public void Dispose();
    }
}
