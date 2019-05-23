using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LoadFiles.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<File> Files { get; set; }

        public User() => Files = new Collection<File>();
    }
}