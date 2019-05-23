using System.IO;
using System.Linq;

namespace LoadFiles.Settings
{
    public class FileLoading
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool isAcceptedFileType(string fileName) {
            return AcceptedFileTypes.Contains(Path.GetExtension(fileName).ToLower());
        }

        public string AcctptedFileTypesAsString => string.Join(", ", AcceptedFileTypes);
    }
}