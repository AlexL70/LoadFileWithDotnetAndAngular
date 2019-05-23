using System;
using System.ComponentModel.DataAnnotations;

namespace LoadFiles.Core.Models.Resources
{
    public class FileResource
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Size { get; set; }
        public DateTime UploadDate { get; set; }
        public UserResource User { get; set; }
    }
}