using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDApp.Models
{
    public class Component
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

        [StringLength(100)]
        public string? SystemName { get; set; }

        [Required, StringLength(100)]
        public string? Type { get; set; }

        [StringLength(50)]
        public string? Dimensions { get; set; }

        [StringLength(100)]
        public string? Material { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; } = "Planned";

        [StringLength(2000)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ComponentFile> Files { get; set; } = new List<ComponentFile>();

    }
}
