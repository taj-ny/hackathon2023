using CommunityToolkit.Mvvm.ComponentModel;
using dobra3.Sdk.Enums;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class ChatBubbleViewModel : ObservableObject
    {
        [ObservableProperty] private string? _Message;
        [ObservableProperty] private SenderType _SenderType;
    }
}
