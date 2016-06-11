using MVVM23052016.Model;
using MVVM23052016.Persistency;
using MVVM23052016.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM23052016.Handler
{
    class SculptureHandler
    {
        public SculptureViewModel SculptureViewModel { get; set; }

        public SculptureHandler(SculptureViewModel sculptureViewModel)
        {
            SculptureViewModel = sculptureViewModel;
        }

   
        public void CreateSculpture()
        {
            Sculpture sculpture = new Sculpture();
            sculpture.Sculpture_Id = SculptureViewModel.NewSculpture.Sculpture_Id;
            sculpture.Sculpture_Name = SculptureViewModel.NewSculpture.Sculpture_Name;
            sculpture.Sculpture_Adress = SculptureViewModel.NewSculpture.Sculpture_Adress;
            sculpture.Sculpture_Placement = SculptureViewModel.NewSculpture.Sculpture_Placement;
            sculpture.TypeLoc = SculptureViewModel.NewSculpture.TypeLoc;
            sculpture.Material = SculptureViewModel.NewSculpture.Material;
            //sculpture.Damages = SculptureViewModel.NewSculpture.Damages;
            //sculpture.Notes = SculptureViewModel.NewSculpture.Notes;
            //sculpture.Treatments = SculptureViewModel.NewSculpture.Treatments;
            new PersistenceFacade().SaveSculpture(sculpture);

            //  SculptureViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture);
            var sculptures = new PersistenceFacade().GetSculptures();
            SculptureViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach (var sculpture1 in sculptures)
            {
                SculptureViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture1);
            }
            SculptureViewModel.NewSculpture.Sculpture_Id = 0;
            SculptureViewModel.NewSculpture.Sculpture_Name = "";
            SculptureViewModel.NewSculpture.Sculpture_Adress = "";
            SculptureViewModel.NewSculpture.Sculpture_Placement = "";
            SculptureViewModel.NewSculpture.Material = "";
            SculptureViewModel.NewSculpture.TypeLoc = "";
            // SculptureViewModel.NewSculpture.Damages = new Damage[];
            // SculptureViewModel.NewSculpture.Notes = new Note[];
            //  SculptureViewModel.NewSculpture.Treatments = new Treatment[];
        }
        public void ViewSculpture()
        {
         
            int TheSculp_Id = SculptureViewModel.NewSculpture.Sculpture_Id;
            SculptureViewModel.NewSculpture = SculptureViewModel.SculptureCatalogSingleton.Sculptures[TheSculp_Id];
          
        }
        public void DeleteSculpture()
        {
            //int deletesculptureId = SculptureViewModel.SelectedSculpture.Sculpture_Id;
          //  int deletesculptureId = SculptureViewModel.NewSculpture.Sculpture_Id;
              //new PersistenceFacade().DeleteSculpture(deletesculptureId);
            new PersistenceFacade().DeleteSculpture(SculptureViewModel.SelectedSculpture);
            //Updated the Listview
            // SculptureViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture);
            var sculptures = new PersistenceFacade().GetSculptures();
            SculptureViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach(var sculpture1 in sculptures)
            {
                SculptureViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture1);
            }
            SculptureViewModel.NewSculpture.Sculpture_Id = 0;
            SculptureViewModel.NewSculpture.Sculpture_Name = "";
            SculptureViewModel.NewSculpture.Sculpture_Adress = "";
            SculptureViewModel.NewSculpture.Sculpture_Placement = "";
            SculptureViewModel.NewSculpture.Material = "";
            SculptureViewModel.NewSculpture.TypeLoc = "";
        //     SculptureViewModel.NewSculpture.Damages = new Damage[];
            // SculptureViewModel.NewSculpture.Notes = new Note[];
            //  SculptureViewModel.NewSculpture.Treatments = new Treatment[];
        }
        public void UpdateSculpture()
        {
            Sculpture sculptureToUpdate = new Sculpture()
            {
                Sculpture_Id = SculptureViewModel.NewSculpture.Sculpture_Id,
                Sculpture_Name = SculptureViewModel.NewSculpture.Sculpture_Name,
                Sculpture_Adress = SculptureViewModel.NewSculpture.Sculpture_Adress,
                Sculpture_Placement= SculptureViewModel.NewSculpture.Sculpture_Placement,
                Material= SculptureViewModel.NewSculpture.Material,
                TypeLoc= SculptureViewModel.NewSculpture.TypeLoc             
            };
            new PersistenceFacade().UpdateSculpture(sculptureToUpdate);
                 //Updated the ListView
            // SculptureViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture);
            var sculptures = new PersistenceFacade().GetSculptures();
            SculptureViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach(var sculpture1 in sculptures)
            {
                SculptureViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture1);
            }
            SculptureViewModel.NewSculpture = new Sculpture();
        }
        public void AddDamage()
        {
           
         int Sculpture_Id = SculptureViewModel.SelectedSculpture.Sculpture_Id;
            int damageId = SculptureViewModel.NewDamage.Damage_Id;
            string damageName = SculptureViewModel.NewDamage.Damage_Name;
            string damageCare = SculptureViewModel.NewDamage.Damage_Care;

            Damage d = new Damage(); //new instance of sculptures damage
            d.Sculpture_Id = Sculpture_Id;
            d.Damage_Id = damageId;
            d.Damage_Name = damageName;
            d.Damage_Care = damageCare;

            new PersistenceFacade().SaveDamage(d);
            var sculptures = new PersistenceFacade().GetSculptures();
            SculptureViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach (var sculpture1 in sculptures)
            {
                SculptureViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture1);
            }
            SculptureViewModel.NewSculpture.Sculpture_Id = 0;
            SculptureViewModel.NewSculpture.Sculpture_Name = "";
            SculptureViewModel.NewSculpture.Sculpture_Adress = "";
        }
    }
}
