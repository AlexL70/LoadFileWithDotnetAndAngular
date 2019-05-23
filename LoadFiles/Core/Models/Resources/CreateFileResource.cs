using System;
using System.ComponentModel.DataAnnotations;

namespace LoadFiles.Core.Models.Resources
{
    public class CreateFileResource
    {
        [Required] [StringLength(255)]
        public string Name { get; set; }
        public int Size { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; }
    }
}