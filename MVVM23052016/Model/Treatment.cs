using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM23052016.Model
{
    class Treatment
    {
        public int Treatment_Id { get; set; }
        public DateTime Last_treatmentDate { get; set; }
        public DateTime Next_treatmentDate { get; set; }
        public int Frequency { get; set; }
        public string Treatment_Recom { get; set; }
        public DateTime NextSupervision_Date { get; set; }
        public string Cultural_Value { get; set; }

        public Treatment(int treatment_Id, DateTime last_treatmentDate, DateTime next_treatmentDate, int frequency, string treatment_Recom, DateTime nextSupervision_Date, string cultural_Value)
        {
            Treatment_Id = treatment_Id;
            Last_treatmentDate = last_treatmentDate;
            Next_treatmentDate = next_treatmentDate;
            Frequency = frequency;
            Treatment_Recom = treatment_Recom;
            Next_treatmentDate = next_treatmentDate;
            Cultural_Value = cultural_Value;
        }

        public Treatment()
        {

        }

        public override string ToString()
        {
            return $"Treatment_Id{Treatment_Id},Last_treatmentDate{Last_treatmentDate},Next_treatmentDate{Next_treatmentDate},Frequency{Frequency},Treatment_Recom{Treatment_Recom},Next_treatmentDate{Next_treatmentDate},Cultural_Value{Cultural_Value}";
        }
    }
}
