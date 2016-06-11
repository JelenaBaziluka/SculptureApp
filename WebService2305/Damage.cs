namespace WebService2305
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Damage")]
    public partial class Damage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Damage_Id { get; set; }

        public int Sculpture_Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Damage_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Damage_Care { get; set; }

        public virtual Sculpture Sculpture { get; set; }
    }
}
