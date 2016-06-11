using MVVM23052016.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM23052016.Model
{
    class SculptureCatalogSingleton
    {
        private static SculptureCatalogSingleton instance = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance
        {
            get { return instance; }
        }
        public ObservableCollection<Sculpture> Sculptures { get; set; }
      //  public ObservableCollection<Damage> AllDamages { get; set; }
        public ObservableCollection<string> SculptureDamages { get; set; }
        public ObservableCollection<string> SculptureCare { get; set; }

        private SculptureCatalogSingleton()
        {
            Sculptures = new ObservableCollection<Sculpture>();
            //Sculpture s1 = new Sculpture(1, "Marmaid", "Kopenhavn Canal", "ground", "Sculpture", "Marmor");
            //Sculpture s2 = new Sculpture(2, "Marmaid", "Kopenhavn Canal", "ground", "Sculpture", "Marmor");
            //Sculptures.Add(s1);
            //Sculptures.Add(s2);
            Sculptures = new ObservableCollection<Sculpture>(new PersistenceFacade().GetSculptures());
            //AllDamages = new ObservableCollection<Damage>(new PersistenceFacade().GetAllDamages());
            SculptureDamages = new ObservableCollection<string>();
            SculptureCare= new ObservableCollection<string>();
            SculptureDamages.Add("missing joints");
            SculptureDamages.Add("Losst of parts/ material");
            SculptureDamages.Add("Detoriation / weathering");
            SculptureDamages.Add("missing joints");
            SculptureDamages.Add("discoloration");
            SculptureDamages.Add("damage due to constructions");
            SculptureDamages.Add("cracks");
            SculptureDamages.Add("Biological growth");
            SculptureDamages.Add("Other damages");
            SculptureCare.Add("joints reconstruction");
            SculptureCare.Add("reconstruction or replacement of the base");
            SculptureCare.Add("cleaning / washing");
            SculptureCare.Add("joints reconstruction");
            SculptureCare.Add("antigraffiti treatment");
            SculptureCare.Add("consolidation");
            SculptureCare.Add("surface treatment");
            SculptureCare.Add("vax");
        }
        public void AddSculpture(int Sculpture_Id, string Sculpture_Name, string Sculpture_Adress, string Sculpture_Placement, string TypeLoc, string Material)
        {
            Sculptures.Add(new Sculpture(Sculpture_Id, Sculpture_Name, Sculpture_Adress, Sculpture_Placement, TypeLoc, Material));
        }
    }
}

