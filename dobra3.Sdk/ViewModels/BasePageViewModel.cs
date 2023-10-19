using CommunityToolkit.Mvvm.ComponentModel;
using dobra3.Sdk.Enums;
using dobra3.Sdk.Services;

namespace dobra3.Sdk.ViewModels
{
    public abstract class BasePageViewModel : ObservableObject, INavigationTarget
    {
        public virtual void OnNavigatingTo(NavigationType navigationType)
        {
        }

        public virtual void OnNavigatingFrom()
        {
        }
    }
}
