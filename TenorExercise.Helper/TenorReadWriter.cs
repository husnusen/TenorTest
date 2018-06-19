using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenorExercise.Common;
using TenorExercise.Helper;
using TenorExercise.Helper.Injection;
using TenorExercise.Helper.Interfaces; 

namespace TenorExercise.Helper
{
    public class TenorReadWriter : ITenorReaderWriter

    {
        private IFileReader _fileReader;
        private IFileWriter _fileWriter;

        public TenorReadWriter()
        {
            IWindsorContainer _container = Bootstrapper.InitializeContainer();
            _fileReader = _container.Resolve<IFileReader>();
            _fileWriter = _container.Resolve<IFileWriter>();
        }

        public TenorReadWriter(IFileReader fileReader, IFileWriter fileWriter)
        {
            this._fileReader = fileReader;
            this._fileWriter = fileWriter;
        }

         
        public void Close()
        {
            _fileReader?.Close();
            _fileWriter?.Close();
        }

        public List<Tenor> GetTenorList()
        {

            List<Tenor> _tenor = new List<Tenor>();
            List<string> lines=null;
            string[] lineArray = null;

            OpenForRead(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), Constants.FilePath));
            lines = Read().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries ).ToList();
            lines.RemoveAt(0);
              foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line)) continue;
                lineArray = line.Split(Constants.RowSeperator);

                try
                {
                    _tenor.Add(new Tenor()
                    {
                        TenorId = lineArray[0],
                        PortfolioId = lineArray[1],
                        Value = Convert.ToDecimal(lineArray[2])
                    });
                }
                catch (Exception ex)
                {

                }

            }
            return _tenor;

        }

        public List<Tenor> OrderByPortfolioIdAndTenor(List<Tenor> tenor)
        {
            return tenor.OrderBy(x => x.TenorId).ThenBy(x => x.PortfolioId).ToList();
        }

        public List<Tenor> OrderByTenorAndPortfolioID(List<Tenor> tenor)
        {
            return tenor.OrderBy(x => x.PortfolioId).ThenBy(x => x.TenorId).ToList();
        }

        public bool IsFileExist(string fileName)
                    => _fileReader.IsFileExist(fileName);

        public void OpenForRead(string fileName)
        {
            if (IsFileExist(fileName))
            {
                if (_fileReader == null)
                    _fileReader = new FileReader();
                _fileReader.Open(fileName);

            }
        }

        public void OpenForWrite(string fileName)
        {
            if (_fileWriter == null)
                _fileWriter = new FileWriter();
            _fileWriter.Open(fileName);
        }

        public string Read()
        {
            return _fileReader.Read();
        }

        public void Write(string lines)
        {
            _fileWriter.Write(lines);
        }
    }
}
