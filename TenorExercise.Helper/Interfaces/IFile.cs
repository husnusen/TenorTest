using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorExercise.Helper.Interfaces
{

    public interface IFile
    {

        bool IsFileExist(string path);

        void Open(string path);

        void Close();
         

    }
}
