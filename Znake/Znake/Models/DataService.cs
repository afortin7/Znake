using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znake.Models
{
    public class DataService : IDataService
    {
        public ObservableCollection<Colonnes> InitGrille(int numRow, int numCol)
        {
            ObservableCollection<Colonnes> grille = new ObservableCollection<Colonnes>();

            for (int i = 0; i < numRow; i++)
            {
                ObservableCollection<Case> colonne = new ObservableCollection<Case>();
                Colonnes colonnes = new Colonnes();
                for (int j = 0; j < numCol; j++)
                    colonne.Add(new Case() { Etat = Etat.Vide, Position = new Position() { X = i, Y = j } });
                colonnes.Colonne = colonne;
                grille.Add(colonnes);
            }
            return grille;
        }

        public ObservableCollection<Colonnes> ModificationGrille(ObservableCollection<Colonnes> grille, Case caseAModifier)
        {
            foreach (var colonnes in grille)
            {
                if (colonnes.Colonne.Any(x => x.Position.X == caseAModifier.Position.X && x.Position.Y == caseAModifier.Position.Y))
                    colonnes.Colonne.Where(x => x.Position.X == caseAModifier.Position.X && x.Position.Y == caseAModifier.Position.Y).ToList().ForEach(y => y.Etat = caseAModifier.Etat);
            }
            return grille;
        }
    }
}
