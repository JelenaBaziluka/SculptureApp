using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SculptureMVVM.Annotations;
using SculptureMVVM.Common;
using SculptureMVVM.Handler;
using SculptureMVVM.Model;

namespace SculptureMVVM.ViewModel
{
    class SculptureViewModel: INotifyPropertyChanged
    {
        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }
        public Handler.SculptureHandler SculptureHandler { get; set; }
       public ICommand CreateCommand { get; set; }



        public SculptureViewModel()
        {
            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;
            SculptureHandler = new Handler.SculptureHandler(this);
            NewSculpture = new Sculpture();
           CreateCommand = new RelayCommand(SculptureHandler.CreateSculpture);

        }

        // Add the a property of type Sculpture
        private Sculpture _newSculpture;

        public Sculpture NewSculpture
        {
            get { return _newSculpture; }
            set { _newSculpture = value; OnPropertyChanged(); }
        }

        //public void AddSculpture()
        //{
        //    SculptureHandler.CreateSculpture(NewSculpture);
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
