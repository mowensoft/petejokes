namespace PeteJokes.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ComedyClub : DbContext
    {
        public ComedyClub()
            : base("name=ComedyClub")
        {
        }

        public virtual DbSet<Evidence> Evidences { get; set; }
        public virtual DbSet<Joke> Jokes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evidence>()
                .Property(e => e.MimeType)
                .IsUnicode(false);

            modelBuilder.Entity<Joke>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Joke>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Joke>()
                .HasMany(e => e.Evidences)
                .WithRequired(e => e.Joke)
                .WillCascadeOnDelete(false);
        }
    }
}
