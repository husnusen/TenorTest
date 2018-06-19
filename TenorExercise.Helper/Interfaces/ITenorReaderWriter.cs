using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenorExercise.Common;

namespace TenorExercise.Helper.Interfaces
{
   public interface ITenorReaderWriter
    {
        bool IsFileExist(string fileName);
        void OpenForRead(string fileName);
        void OpenForWrite(string fileName);
        void Close();
        string Read();
        void Write(string lines);
        List<Tenor> GetTenorList();
        List<Tenor> OrderByTenorAndPortfolioID(List<Tenor> tenor);
        List<Tenor> OrderByPortfolioIdAndTenor(List<Tenor> tenor); 
    }
}
