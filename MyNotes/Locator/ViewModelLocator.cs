using Autofac;
using MVVMBase;
using View.Helper;
using ViewModel.Interfaces;
using ViewModel.MockViewModels;

namespace View.Locator
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        public ITrayViewModel TrayViewModel => IsInDesignMode()
            ? new MockTrayViewModel()
           : IocContainer.Instance.Container.Resolve<ITrayViewModel>();

        public IMainViewModel MainViewModel => IsInDesignMode()
            ? new MockMainViewModel()
            : IocContainer.Instance.Container.Resolve<IMainViewModel>();

        public IQuickNoteViewModel QuickNoteViewModel => IsInDesignMode()
           ? new MockQuickNoteViewModel()
           : IocContainer.Instance.Container.Resolve<IQuickNoteViewModel>();
    }
}