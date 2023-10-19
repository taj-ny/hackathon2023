using CommunityToolkit.Mvvm.ComponentModel;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class ChatBubbleViewModel : ObservableObject
    {
        [ObservableProperty] private string? _Message;
    }
}
