namespace WebService2305
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Note")]
    public partial class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Note_Id { get; set; }

        public int? Sculpture_Id { get; set; }

        [StringLength(100)]
        public string Note_Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Note_Date { get; set; }

        [Column(TypeName = "text")]
        public string Note_Description { get; set; }

        public virtual Sculpture Sculpture { get; set; }
    }
}
