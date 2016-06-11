using System.Web.Http;

namespace WebServiceDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SculptureContext : DbContext
    {
        public SculptureContext()
            : base("name=SculptureContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(
                GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        public virtual DbSet<Damage> Damages { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Sculpture> Sculptures { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Damage>()
                .Property(e => e.Damage_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Damage>()
                .Property(e => e.Damage_Care)
                .IsUnicode(false);

            modelBuilder.Entity<Note>()
                .Property(e => e.Note_Title)
                .IsUnicode(false);

            modelBuilder.Entity<Note>()
                .Property(e => e.Note_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Placement)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Material)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.TypeLoc)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .HasMany(e => e.Damages)
                .WithRequired(e => e.Sculpture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Treatment_Recom)
                .IsUnicode(false);
        }
    }
}
