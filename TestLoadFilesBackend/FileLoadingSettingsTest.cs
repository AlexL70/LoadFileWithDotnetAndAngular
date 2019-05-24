using System;
using LoadFiles.Controllers;
using LoadFiles.Core;
using LoadFiles.Settings;
using Moq;
using Xunit;


namespace TestLoadFilesBackend
{
    public class FileLoadingSettingsTest
    {

        [Fact]
        public void TestAllowedTypesString()
        {
            var fls = new FileLoading();
            fls.AcceptedFileTypes = new string[] { ".pdf", ".jpg", ".jpeg"};
            Assert.Equal(".pdf, .jpg, .jpeg", fls.AcctptedFileTypesAsString);
        }

        [Fact]
        public void TestFileAllowed()
        {
            var fls = new FileLoading();
            fls.AcceptedFileTypes = new string[] { ".pdf", ".jpg", ".jpeg" };
            Assert.False(fls.isAcceptedFileType("SomeFile.xml"));
            Assert.True(fls.isAcceptedFileType("AnotherFile.jpg"));
        }
    }
}
