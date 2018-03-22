using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Znake.Models;

namespace Znake.ViewModels
{
    public class ClavardageHud_ViewModel : Base_ViewModel
    {
        private readonly IDataService _dataService;

        private Salles _salleCourante;
        public Salles SalleCourante
        {
            get { return _salleCourante; }
            set
            {
                if (value == _salleCourante) return;
                _salleCourante = value;
                RaisePropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (value == _message) return;
                _message = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<Conversations> _conversations;
        public ObservableCollection<Conversations> Conversations
        {
            get { return _conversations; }
            set
            {
                if (value == _conversations) return;
                _conversations = value;
                RaisePropertyChanged();
            }
        }
        public ClavardageHud_ViewModel(Salles salle, IDataService dataService)
        {
            SalleCourante = salle ?? new Salles() {Description = "Salle demo", Id = 1, Nom = "Salle Demo"};
            _dataService = dataService;

            if(dataService != null)
                Conversations = _dataService.GetConversations(salle);
        }

        public ICommand EnvoyerMessageCommand => new RelayCommand(EnvoyerMessage);

        private void EnvoyerMessage()
        {
            Conversations.Add(new Conversations {Interne = Message});
            Message = String.Empty;
        }
    }
}
