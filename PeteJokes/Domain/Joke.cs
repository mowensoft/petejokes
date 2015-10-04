namespace PeteJokes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Joke")]
    public partial class Joke
    {
        public Joke()
        {
            Evidences = new HashSet<Evidence>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(4000)]
        public string Text { get; set; }

        public DateTime ToldOn { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public int UpGoats { get; set; }

        public int DownBoats { get; set; }

        public virtual ICollection<Evidence> Evidences { get; set; }
    }
}
