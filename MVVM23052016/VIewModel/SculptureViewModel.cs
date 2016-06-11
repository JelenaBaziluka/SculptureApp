using MVVM23052016.Common;
using MVVM23052016.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM23052016.VIewModel
{
    class SculptureViewModel : INotifyPropertyChanged
    {
        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }
        public Handler.SculptureHandler SculptureHandler { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand ViewSculptureCommand { get; set; }
        public ICommand DeleteCommand { get; set;}
        public ICommand UpdateCommand { get; set;}
        public ICommand AddDamageCommand { get; set;}


        public SculptureViewModel()
        {
            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;
            SculptureHandler = new Handler.SculptureHandler(this);
            NewSculpture = new Sculpture();
            NewDamage = new Damage();

            CreateCommand = new RelayCommand(SculptureHandler.CreateSculpture);
            ViewSculptureCommand = new RelayCommand(SculptureHandler.ViewSculpture);
            DeleteCommand = new RelayCommand(SculptureHandler.DeleteSculpture);
            UpdateCommand = new RelayCommand(SculptureHandler.UpdateSculpture);
            AddDamageCommand = new RelayCommand(SculptureHandler.AddDamage);
        }

        // Add the a property of type Sculpture
       

        private Sculpture _selectedSculpture;
        public Sculpture SelectedSculpture
        {
            get { return _selectedSculpture; }
            set { _selectedSculpture = value; OnPropertyChanged(); }
        }


        private Sculpture _newSculpture;
        public Sculpture NewSculpture
        {
            get { return _newSculpture; }
            set { _newSculpture = value; OnPropertyChanged(); }
        }

        private Damage _selectedDamage;
        public Damage SelectedDamage
        {
            get { return _selectedDamage; }
            set { _selectedDamage = value; OnPropertyChanged(); }
        }
        private Damage _newDamage;
        public Damage NewDamage
        {
            get { return _newDamage; }
            set { _newDamage = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]     string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
