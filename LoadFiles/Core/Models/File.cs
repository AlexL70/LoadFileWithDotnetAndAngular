using System;
using System.ComponentModel.DataAnnotations;

namespace LoadFiles.Core.Models
{
    public class File
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Size { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string UploadPath { get; set; }
    }
}