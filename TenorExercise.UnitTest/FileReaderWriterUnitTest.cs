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


        /// <summary>
        /// Check that is the file exist or not
        /// </summary>
        [Test]
        void CheckIsFileExist_Test()
        {
            Assert.IsTrue(_tenorReaderWriter.IsFileExist("test"));

        }

        /// <summary>
        /// Test for clos streams.
        /// </summary>
        [Test]
        void CloseAllStreams_Test()
        {
            _tenorReaderWriter.Close();

            _fileReader.Verify(x => x.Close(), Times.Once);
            _fileWriter.Verify(y => y.Close(), Times.Once);
        }

        /// <summary>
        /// Test to open file to read
        /// </summary>
        [Test]
        void OpenToReadFile_Test()
        {
            _tenorReaderWriter.OpenForRead("data.txt");
            _fileReader.Verify(x => x.Open("data.txt"), Times.Once);

        }

        /// <summary>
        /// Test to create new file to write new list
        /// </summary>
        [Test]
        void OpenFileToWrite_Test()
        {
            _tenorReaderWriter.OpenForWrite("3.txt");
            _fileWriter.Verify(x => x.Open("3.txt"), Times.Once);

        }

        /// <summary>
        /// Test to read file
        /// </summary>
        [Test]
        void ReadListFromFile_Test()
        {
            var result = _tenorReaderWriter.Read();
            Assert.IsNotEmpty(result);
        }

        /// <summary>
        /// Test to write file
        /// </summary>
        [Test]
        void WriteListToFile_Test()
        {
            _tenorReaderWriter.Write("test");
            _fileWriter.Verify(x => x.Write("test"), Times.Once);

        }


        /// <summary>
        /// Test to get tenor list from file as List
        /// </summary>
        [Test]
        void GetTenorList_Test()
        {
            var result = _tenorReaderWriter.GetTenorList();
            Assert.IsNotNull(result);
        }


        /// <summary>
        /// Test to order by Portfolio and Tenor
        /// </summary>
        [Test]
        void OrderByPortfolioIdAndTenor_Test()
        {
            var result = _tenorReaderWriter.OrderByPortfolioIdAndTenor(_tenorReaderWriter.GetTenorList());
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test to order by Tenor and Portfolio
        /// </summary>
        [Test]
        void OrderByTenorAndPortfolioID_Test()
        {
            var result = _tenorReaderWriter.OrderByTenorAndPortfolioID(_tenorReaderWriter.GetTenorList());
            Assert.IsNotNull(result);
        }
    }
}
