using Avalonia.Controls;
using Avalonia.Platform.Storage;
using dobra3.Sdk.Services;
using dobra3.Views;
using System.Linq;
using System.Threading.Tasks;

namespace dobra3.ServiceImplementation
{
    internal sealed class FileExplorerService : IFileExplorerService
    {
        public async Task<string?> PickFileAsync(string filter)
        {
            var topLevel = TopLevel.GetTopLevel(MainWindow.Instance);

            var items = await topLevel.StorageProvider.OpenFilePickerAsync(new()
            {
                AllowMultiple = false,
                FileTypeFilter = new FilePickerFileType[] { new(filter) },

            });

            return items.FirstOrDefault()?.Path.LocalPath;
        }
    }
}
