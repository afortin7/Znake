/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:GolfinMonitorLite.ViewModels"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Ioc;
//using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Znake.Models;

namespace Znake.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            SimpleIoc.Default.Register<IDataService, DataService>();
            //}


            SimpleIoc.Default.Register<Main_ViewModel>();
            //SimpleIoc.Default.Register<Znake_ViewModel>();
            //SimpleIoc.Default.Register<ClavardageHud_ViewModel>(() => new ClavardageHud_ViewModel(null, null));
            //Ici on register les nouveau View Model

        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public Main_ViewModel Main => ServiceLocator.Current.GetInstance<Main_ViewModel>();
        //public Znake_ViewModel ZnakeViewModel => ServiceLocator.Current.GetInstance<Znake_ViewModel>();
       // public ClavardageHud_ViewModel ClavardageHudViewModel => ServiceLocator.Current.GetInstance<ClavardageHud_ViewModel>();



        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            //Delete les threads
        }
    }
}