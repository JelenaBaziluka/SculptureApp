using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM23052016.Model
{
    class Note
    {
        public int Note_Id;
        public DateTime Note_Date;
        public string Note_Title;
        public string Note_Description;

        public Note(int note_id, DateTime dateTime, string noteTitle, string noteDescription)
        {
            Note_Id = note_id;
            Note_Date = dateTime;
            Note_Title = noteTitle;
            Note_Description = noteDescription;
        }
        public Note()
        {

        }

        public override string ToString()
        {
            return $" Note_ID {Note_Id} DateTime{Note_Date} NoteTitle{Note_Title} NoteDescription{Note_Description} ";
        }
    }
}
