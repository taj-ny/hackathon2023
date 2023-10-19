using OwlCore.Storage;

namespace dobra3.Sdk.Services
{
    public interface IFileExplorerService
    {
        Task<string?> PickFileAsync(string filter);
    }
}
