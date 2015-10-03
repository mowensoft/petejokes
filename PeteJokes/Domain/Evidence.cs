namespace PeteJokes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evidence")]
    public partial class Evidence
    {
        public int Id { get; set; }

        public int JokeId { get; set; }

        [Required]
        [StringLength(100)]
        public string MimeType { get; set; }

        [Required]
        public byte[] Data { get; set; }

        public virtual Joke Joke { get; set; }
    }
}
