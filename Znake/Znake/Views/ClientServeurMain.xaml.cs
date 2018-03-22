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
using Znake.ViewModels;

namespace Znake.Views
{
    /// <summary>
    /// Interaction logic for ClientServeurMain.xaml
    /// </summary>
    public partial class ClientServeurMain : Window
    {
        public ClientServeurMain()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
