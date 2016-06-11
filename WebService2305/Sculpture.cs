namespace WebService2305
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sculpture")]
    public partial class Sculpture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sculpture()
        {
            Damages = new HashSet<Damage>();
            Notes = new HashSet<Note>();
            Treatments = new HashSet<Treatment>();
        }

        public Sculpture(string name, string adress, string placement, string material, string typeLoc)
        {
            Damages = new HashSet<Damage>();
            Notes = new HashSet<Note>();
            Treatments = new HashSet<Treatment>();

            Sculpture_Name = name;
            Sculpture_Adress = adress;
            Sculpture_Placement = placement;
            Material = material;
            TypeLoc = typeLoc;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sculpture_Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture_Link { get; set; }

        [Required]
        [StringLength(100)]
        public string Sculpture_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Sculpture_Adress { get; set; }

        [Required]
        [StringLength(50)]
        public string Sculpture_Placement { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Material { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string TypeLoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Damage> Damages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Note> Notes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treatment> Treatments { get; set; }
        //public override string ToString()
        //{
        //    string damages = "";
        //    foreach (var d in Damages)
        //    {
        //        damages += d.Damage_Id + "," + d.Damage_Name + "," + d.Damage_Care;
        //    }
        //    return string.Format("Sculpture_Id {0} Sculpture_Name{1} Sculpture_Adress{2} Sculpture_Placement{3} TypeLoc{4} Material{5} Damage_Name {6} Damage_Care{7}",
        //       Sculpture_Id, Sculpture_Name, Sculpture_Adress, Sculpture_Placement, TypeLoc, Material, damages);
        //    //  return $"Sculpture_No {Sculpture_Id} Name {Sculpture_Name} Adress {Sculpture_Adress}  Placement {Sculpture_Placement} TypeLoc {TypeLoc} Material{Material} ";
        //}
    }
}
