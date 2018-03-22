using System;
using System.Windows;
using System.Windows.Threading;
using Znake.Models;
using Znake.ViewModels;

namespace Znake.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
