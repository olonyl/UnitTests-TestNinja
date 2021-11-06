using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    class InstallerHelperTests
    {
        InstallerHelper _installerHelper;
        Mock<IFileDownloader> _fileDownloader;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_CallValidURL_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.IsTrue(result);
        }

        [Test]
        public void DownloadInstaller_CallInvalidURL_ReturnFalse()
        {
            _fileDownloader.Setup(su => su.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws(new WebException());

            var result = _installerHelper.DownloadInstaller("", "");

            Assert.IsFalse(result);
        }
    }
}
