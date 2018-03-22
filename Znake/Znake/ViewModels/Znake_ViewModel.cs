using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Znake.Auxiliary.Helpers;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using Znake.Models;
using Znake.Views;

namespace Znake.ViewModels
{
    public class Znake_ViewModel : Base_ViewModel
    {
        private readonly IDataService _dataService;

        #region Constructor

        public Znake_ViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Utilisateurs = _dataService.GetUtilisateurs();
            Salles = _dataService.GetSallesActive();
        }

        #endregion
        #region View Model Properties
        // public Znake_ViewModel Znake_ViewModel => ServiceLocator.Current.GetInstance<Znake_ViewModel>();
        #endregion

        #region Properties
        private ObservableCollection<Salles> _salles;
        public ObservableCollection<Salles> Salles
        {
            get { return _salles; }
            set
            {
                if (value == _salles) return;
                _salles = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Utilisateurs> _utilisateurs;
        public ObservableCollection<Utilisateurs> Utilisateurs
        {
            get { return _utilisateurs; }
            set
            {
                if (value == _utilisateurs) return;
                _utilisateurs = value;
                RaisePropertyChanged();
            }
        }

        private UserControl _clavardageHudUC;
        public UserControl ClavardageHudUC
        {
            get { return _clavardageHudUC; }
            set
            {
                if (value == _clavardageHudUC) return;
                _clavardageHudUC = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region LoginCommand
        public ICommand SabonnerCommand => new RelayCommand<object>(AbonnerUtilisateur);
        public ICommand VoirProfileCommand => new RelayCommand(VoirProfileUtilisateurConnecter);
        public ICommand DeconnexionCommand => new RelayCommand(Deconnexion);
        public ICommand AllerSalleCommand => new RelayCommand<Salles>(AllerVersSalle);

        private void AllerVersSalle(Salles salle) //Methode pour afficher
        {
            HudClavardage clavardage = new HudClavardage {DataContext = new ClavardageHud_ViewModel(salle, _dataService) };
            ClavardageHudUC = clavardage;
        }

        private void AbonnerUtilisateur(object salle)
        {
            var salleSelectionner = (Salles) salle;
            string nomDeLaSalle = salleSelectionner.Nom;
            //Code ici pour l'abonnement d'un utilisateur a une salle.

        }

        private void VoirProfileUtilisateurConnecter()
        {
            throw new NotImplementedException();
        }
        private void Deconnexion()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
