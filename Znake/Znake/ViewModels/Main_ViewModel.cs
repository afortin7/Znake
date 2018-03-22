using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using Znake.Auxiliary.Helpers;
using Znake.Models;
using Znake.Views;

namespace Znake.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class Main_ViewModel : Base_ViewModel
    {
        private static IDataService _dataService;
        private static DispatcherTimer _dispatcherTimer;
        private static object _itemsLock;
        private int cpt = 0;

        private Serpent serpent;

        #region View Model Properties
        //public Znake_ViewModel ZnakeViewModel => ServiceLocator.Current.GetInstance<Znake_ViewModel>();
        #endregion

        public Main_ViewModel(IDataService dataService)
        {
            _dataService = dataService;

            _itemsLock = new object();
            Grille = _dataService.InitGrille(30, 30);
            BindingOperations.EnableCollectionSynchronization(Grille, _itemsLock);

            serpent = new Serpent()
            {
                DerniereDirection = Direction.Ouest,
                NumSerpent = 1,
                Queue = new List<Position>(),
                Tete = new Position() { X = 0, Y = 0 }
            };

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100); //Every 100ms
            _dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lock (_itemsLock) //Pas necessaire pour la
            {
                // Once locked, you can manipulate the collection safely from another thread
                Position nouvellePosition = new Position() { X = serpent.Tete.X + serpent.DerniereDirection.X, Y = serpent.Tete.Y + serpent.DerniereDirection.Y };
                ObservableCollection<Colonnes> nouvelleGrille = _dataService.ModificationGrille(Grille, new Case() { Etat = Etat.Serpent, Position = nouvellePosition });
                Grille = new ObservableCollection<Colonnes>(); //On doit reset la grille pour que cela fonctionne !
                Grille = nouvelleGrille;
                serpent.Tete = nouvellePosition;
            }
        }

        #region Properties
        private ObservableCollection<Colonnes> _grille;
        public ObservableCollection<Colonnes> Grille
        {
            get { return _grille; }
            set
            {
                if (value == _grille) return;
                _grille = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public ICommand TestCommand => new RelayCommand(Test);
        public ICommand NordCommand => new RelayCommand<string>(ArrowSend);
        public ICommand SudCommand => new RelayCommand<string>(ArrowSend);
        public ICommand EstCommand => new RelayCommand<string>(ArrowSend);
        public ICommand OuestCommand => new RelayCommand<string>(ArrowSend);
        private void ArrowSend(string direction)
        {
            lock (_itemsLock)
            {
                Position nouvellePosition = null;
                switch (direction)
                {
                    case "Nord":
                        nouvellePosition = new Position()
                        {
                            X = serpent.Tete.X + Direction.Nord.X,
                            Y = serpent.Tete.Y + Direction.Nord.Y
                        };
                        serpent.DerniereDirection = Direction.Nord;
                        break;
                    case "Sud":
                        nouvellePosition = new Position()
                        {
                            X = serpent.Tete.X + Direction.Sud.X,
                            Y = serpent.Tete.Y + Direction.Sud.Y
                        };
                        serpent.DerniereDirection = Direction.Sud;
                        break;
                    case "Est":
                        nouvellePosition = new Position()
                        {
                            X = serpent.Tete.X + Direction.Est.X,
                            Y = serpent.Tete.Y + Direction.Est.Y
                        };
                        serpent.DerniereDirection = Direction.Est;
                        break;
                    case "Ouest":
                        nouvellePosition = new Position()
                        {
                            X = serpent.Tete.X + Direction.Ouest.X,
                            Y = serpent.Tete.Y + Direction.Ouest.Y
                        };
                        serpent.DerniereDirection = Direction.Ouest;
                        break;
                }

                if (nouvellePosition != null)
                {
                    ObservableCollection<Colonnes> nouvelleGrille = _dataService.ModificationGrille(Grille,
                        new Case() {Etat = Etat.Serpent, Position = nouvellePosition});

                    Grille = new ObservableCollection<Colonnes>(); //On doit reset la grille pour que cela fonctionne !
                    Grille = nouvelleGrille;
                }
            }

        }
        private void Test()
        {

        }
    }
}
