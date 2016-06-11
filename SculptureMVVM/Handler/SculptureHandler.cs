using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SculptureMVVM.Model;
using SculptureMVVM.Persistency;
using SculptureMVVM.ViewModel;

namespace SculptureMVVM.Handler
{
    class SculptureHandler
    {
        public SculptureViewModel SculptureViewModel { get; set; }

        public SculptureHandler(SculptureViewModel sculptureViewModel)
        {
            SculptureViewModel = sculptureViewModel;
        }

        //public void CreateSculpture()
        //{
        //    Sculpture sculpture = new Sculpture();
        //    new PersistenceFacade().SaveSculpture(sculpture);
        //    var sculptures = new PersistenceFacade().GetSculptures();
        //    SculptureViewModel.SculptureCatalogSingleton.Sculptures.Clear();
        //    foreach (var sculpture1 in sculptures)
        //    {
        //        SculptureViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture1);
        //    }
        //}
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
        }
    }
    

