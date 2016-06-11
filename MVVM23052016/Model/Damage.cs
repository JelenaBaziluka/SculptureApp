using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM23052016.Model
{
    class Damage
    {
        public int Damage_Id { get; set; }
        public string Damage_Name { get; set; }
        public string Damage_Care { get; set; }
        public int Sculpture_Id { get; set; }

        //public Damage(int d_id, string d_name, string d_care)
        //{
        //    Damage_Id = d_id;
        //    Damage_Name = d_name;
        //    Damage_Care = d_care;
        //}

        public Damage()
        {

        }
        public override string ToString()
        {
            return $" DamageId {Damage_Id} DamageName {Damage_Name} Damage_Care {Damage_Care}";
        }
    }
}
