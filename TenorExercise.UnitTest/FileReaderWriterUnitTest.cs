using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenorExercise.Helper.Interfaces;
using TenorExercise.Helper;
namespace TenorExercise.UnitTest
{
    [TestFixture]
    public class FileReaderWriterUnitTest
    {
        ITenorReaderWriter _tenorReaderWriter;
        Mock<IFileReader> _fileReader;
        Mock<IFileWriter> _fileWriter;
        

        [SetUp]
        void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _fileWriter = new Mock<IFileWriter>();

            _tenorReaderWriter = new TenorReadWriter(_fileReader.Object, _fileWriter.Object);
        }

        [Test]
        void IsFileExist()
        {
            Assert.IsTrue(_tenorReaderWriter.IsFileExist("test"));

        }

        [Test]
        void Close()
        {
            _tenorReaderWriter.Close();

            _fileReader.Verify(x => x.Close(), Times.Once);
            _fileWriter.Verify(y => y.Close(), Times.Once);
        }

        [Test]
        void OpenToRead()
        {
            _tenorReaderWriter.OpenForRead("data.txt");
            _fileReader.Verify(x => x.Open("data.txt"), Times.Once);

        }

        [Test]
        void OpenToWrite()
        {
            _tenorReaderWriter.OpenForWrite("3.txt");
            _fileWriter.Verify(x => x.Open("3.txt"), Times.Once);

        }

        [Test]
        void Read()
        {
            var result = _tenorReaderWriter.Read();
            Assert.IsNotEmpty(result);
        }


        [Test]
        void Write()
        {
            _tenorReaderWriter.Write("test");
            _fileWriter.Verify(x => x.Write("test"), Times.Once);

        }

        [Test]
        void GetTenorList()
        {
            var result = _tenorReaderWriter.GetTenorList();
            Assert.IsNotNull(result);
        }

        [Test]
        void OrderByPortfolioIdAndTenor()
        {
            var result = _tenorReaderWriter.OrderByPortfolioIdAndTenor(_tenorReaderWriter.GetTenorList());
            Assert.IsNotNull(result);
        }

        [Test]
        void OrderByTenorAndPortfolioID()
        {
            var result = _tenorReaderWriter.OrderByTenorAndPortfolioID(_tenorReaderWriter.GetTenorList());
            Assert.IsNotNull(result);
        }
    }
}
