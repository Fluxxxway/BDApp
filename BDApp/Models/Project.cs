using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BDApp.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public string InviteCode { get; set; }
        public string InviteCodeHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Component> Components { get; set; } = new List<Component>();
    }
}
