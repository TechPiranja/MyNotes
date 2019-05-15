using System.ComponentModel;
using System.Windows;

namespace MVVMBase
{
    public class ViewModelLocatorBase
    {
        /// <summary>
        /// Base class for ViewModelLocators.
        /// It offers the IsInDesignMode-Method, which indicates whether the view is shown in xaml or is executed.
        /// This offers you the possibility to setup MockViewModels for easier design.
        /// </summary>
        // returns true if editing .xaml file in VS for example
        protected bool IsInDesignMode()
        {
            var result = DesignerProperties.GetIsInDesignMode(new DependencyObject());

            return result;
        }
    }
}