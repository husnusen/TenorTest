using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenorExercise.Helper.Interfaces;

namespace TenorExercise.Helper
{
    public class FileReader : IFileReader
    {
        #region Members

        private StreamReader _streamReader;


        #endregion

        public void Close() => _streamReader?.Close();

        public bool IsFileExist(string path) => File.Exists(path);

        public void Open(string path) => _streamReader = File.OpenText(path);

        public string Read() => _streamReader.ReadToEnd();

    }
}
