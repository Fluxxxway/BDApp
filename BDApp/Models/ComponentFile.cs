using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BDApp.Models
{
    public class ComponentFile
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ComponentId { get; set; }

        [ForeignKey("ComponentId")]
        public Component? Component { get; set; }

        public int? DocumentTypeID { get; set; }
        
        [ForeignKey("DocumentTypeID")]
        public DocumentType? DocumentType { get; set; } 

        public string FileName { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public string? FileExtension { get; set; }

        public long FileSize { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string? UploadedBy { get; set; }

        public string? Notes { get; set; }
    }

    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public DocumentCategory Category { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Code { get; set; }

        public string? Description { get; set; }
    }


    public class DocumentCategory
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        public List<DocumentType> DocumentTypes { get; set; } = new();
    }

}
