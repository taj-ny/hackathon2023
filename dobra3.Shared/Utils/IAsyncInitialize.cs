namespace dobra3.Shared.Utils
{
    public interface IAsyncInitialize
    {
        Task InitAsync(CancellationToken cancellationToken = default);
    }
}