using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenorExercise.Helper.Interfaces;

namespace TenorExercise.Helper
{
    public class FileWriter : IFileWriter
    {
        #region Members
        private StreamWriter _streamWriter;
        #endregion

        #region Methods

        public void Open(string fileName)
        {
            FileInfo fileInfo = new FileInfo(
                Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), "Data",fileName)
                );


            _streamWriter = fileInfo.CreateText(); 

        }

        public void Write(string line) => _streamWriter.WriteLine(line);

        public void Close() => _streamWriter?.Close();

        public bool IsFileExist(string path)
        {
            return File.Exists(path);
        }

        public void CreateFile(string fileName)
        {
            if (!IsFileExist(fileName))
                File.Create(fileName);
        }


        #endregion

    }
}
