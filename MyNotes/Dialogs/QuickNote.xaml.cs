using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View.Dialogs
{
    /// <summary>
    /// Interaction logic for QuickNote.xaml
    /// </summary>
    public partial class QuickNote : Window
    {
        public QuickNote()
        {
            InitializeComponent();
            Left = SystemParameters.WorkArea.Width - Width;
            Top = SystemParameters.WorkArea.Height - Height;
        }
    }
}
