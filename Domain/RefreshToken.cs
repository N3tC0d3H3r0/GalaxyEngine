using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class RefreshToken
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        [Required, StringLength(128)]
        public Guid Token { get; set; }
        public User @User { get; set; }
        public DateTime ToLife { get; set; }
    }
}
