using Prism.Commands;
using Prism.Navigation;

namespace PrismApp2.ViewModels
{
    public interface IViewAViewModel
    {
        DelegateCommand GoHomeCommand { get; }
        DelegateCommand NavigateCommandB { get; }
        string Title { get; set; }

        void OnNavigatedFrom(INavigationParameters parameters);
        void OnNavigatedTo(INavigationParameters parameters);
    }
}