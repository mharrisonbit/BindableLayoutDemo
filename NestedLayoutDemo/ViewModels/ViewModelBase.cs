using Prism.Mvvm;
using Prism.Navigation;

namespace NestedLayoutDemo.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigatedAware
    {
        protected INavigationService _navigationService { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void Initialize(INavigationParameters parameters)
        {
        }
    }
}