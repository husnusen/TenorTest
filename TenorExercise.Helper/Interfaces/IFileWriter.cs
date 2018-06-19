using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorExercise.Helper.Interfaces
{
    public interface IFileWriter:IFile
    {
        void Write(string line);

        void CreateFile(string fileName);
    }
}
