using Autofac;
using MVVMBase;
using View.Helper;
using ViewModel;
using ViewModel.Interfaces;
using ViewModel.MockViewModels;

namespace View.Locator
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        public IMainViewModel MainViewModel => IsInDesignMode()
            ? new MockMainViewModel()
            : IocContainer.Instance.Container.Resolve<IMainViewModel>();
    }
}