namespace WebServiceDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Treatment")]
    public partial class Treatment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Treatment_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Last_treatmentDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Next_treatmentDate { get; set; }

        public int? Frequency { get; set; }

        [StringLength(50)]
        public string Treatment_Recom { get; set; }

        public int? Sculpture_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NextSupervision_Date { get; set; }

        public bool CulturalValue_A { get; set; }

        public bool CulturalValue_B { get; set; }

        public bool CulturalValue_C { get; set; }

        public virtual Sculpture Sculpture { get; set; }
    }
}
