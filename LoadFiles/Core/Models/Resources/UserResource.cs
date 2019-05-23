using System.ComponentModel.DataAnnotations;

namespace LoadFiles.Core.Models.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}