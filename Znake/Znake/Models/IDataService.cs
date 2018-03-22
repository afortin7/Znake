using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znake.Models
{
    public interface IDataService
    {
        //Prototype de tous les fonction nécessaire aux vues.
        //ObservableCollection<Salles> GetSallesActive();
        //ObservableCollection<Utilisateurs> GetUtilisateurs();
        //ObservableCollection<Conversations> GetConversations(Salles salle);
        ObservableCollection<Colonnes> InitGrille(int numRow, int numCol);
        ObservableCollection<Colonnes> ModificationGrille(ObservableCollection<Colonnes> grille, Case caseAModifier);

    }
}
