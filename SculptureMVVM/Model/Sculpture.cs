using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SculptureMVVM.Model
{
    class Sculpture
    {
        public int Sculpture_Id { get; set; }
        public string Sculpture_Name { get; set; }
        public string Sculpture_Adress { get; set; }
        public string Sculpture_Placement { get; set; }
        public string TypeLoc { get; set; }
        public string Material { get; set; }
        //public virtual ICollection<Note> Notes { get; set; }
        //public virtual ICollection<Damage> Damages { get; set; }
        //public virtual ICollection<Treatment> Treatments { get; set; }
        public Sculpture(int sculpNo, string sculpName, string sculpAdress, string sculpPlacement, string sculpType, string material)
        {
            Sculpture_Id = sculpNo;
            Sculpture_Name = sculpName;
            Sculpture_Adress = sculpAdress;
            Sculpture_Placement = sculpPlacement;
            TypeLoc = sculpType;
            Material = material;
        }

        public Sculpture()
        {

        }
        public override string ToString()
        {
            return 
                $"Sculpture_No {Sculpture_Id} Name {Sculpture_Name} Adress {Sculpture_Adress}  Placement {Sculpture_Placement} TypeLoc {TypeLoc} Material{Material} ";
        }
    }
}
