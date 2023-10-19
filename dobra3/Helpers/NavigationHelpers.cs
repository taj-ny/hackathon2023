using dobra3.Sdk.Services;
using dobra3.ServiceImplementation;
using dobra3.Utils;

namespace dobra3.Helpers
{
    public static class NavigationHelpers
    {
        public static void ResetNavigation(this INavigationService navigationService)
        {
            if (navigationService is INavigationControlContract navigationControlContract)
                navigationControlContract.NavigationControl = null;
        }

        public static bool SetupNavigation(this INavigationService navigationService, INavigationControl navigationControl, bool overrideNavigation = false)
        {
            if (!overrideNavigation && navigationService.IsInitialized)
                return true;

            if (navigationService is INavigationControlContract navigationControlContract)
            {
                navigationControlContract.NavigationControl = navigationControl;
                return navigationService.IsInitialized;
            }

            return false;
        }
    }
}
