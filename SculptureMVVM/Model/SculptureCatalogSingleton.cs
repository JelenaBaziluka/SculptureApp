using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SculptureMVVM.Persistency;

namespace SculptureMVVM.Model
{
    class SculptureCatalogSingleton
    {
        private static SculptureCatalogSingleton instance = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance
        {
            get { return instance; }
        }
        public ObservableCollection<Sculpture> Sculptures { get; set; }

        private SculptureCatalogSingleton()
        {
            Sculptures = new ObservableCollection<Sculpture>();
            //Sculpture s1 = new Sculpture(1, "Marmaid", "Kopenhavn Canal", "ground", "Sculpture", "Marmor");
            //Sculpture s2 = new Sculpture(2, "Marmaid", "Kopenhavn Canal", "ground", "Sculpture", "Marmor");
            //Sculptures.Add(s1);
            //Sculptures.Add(s2);
            //Sculptures = new ObservableCollection<Sculpture>(new PersistenceFacade().GetSculptures());

        }
        public void AddSculpture(int Sculpture_Id, string Sculpture_Name, string Sculpture_Adress, string Sculpture_Placement, string TypeLoc, string Material)
        {
            Sculptures.Add(new Sculpture(Sculpture_Id, Sculpture_Name, Sculpture_Adress, Sculpture_Placement, TypeLoc, Material));
        }
    }
}
    