using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenorExercise.Common;
using TenorExercise.Helper;
using TenorExercise.Helper.Interfaces;

namespace TenorExercise
{
    class Program
    {
        private static List<Tenor> _tenor;
        private static List<Tenor> _tempTenor;

        static void Main(string[] args)
        {
            TenorReadWriter _tenorReadWriter = new TenorReadWriter();

             
            _tenor = _tenorReadWriter.GetTenorList();

            foreach (var tenor in _tenor)

            {
                Console.WriteLine($"Tenor:{tenor.TenorId} - " +
                                  $"Portfolio Id: {tenor.PortfolioId} " +
                                  $"- Value:{tenor.Value.ToString()}"
                                  );

            }
            Console.ReadLine();
            Console.WriteLine("Sorted by Tenor & Portfolio ID...");

            foreach (var tenor in _tenorReadWriter.OrderByTenorAndPortfolioID(_tenor))

            {
                Console.WriteLine($"Tenor:{tenor.TenorId} - " +
                                  $"Portfolio Id: {tenor.PortfolioId} " +
                                  $"- Value:{tenor.Value.ToString()}"
                                  );

            }

            Console.ReadLine();
            Console.WriteLine("Sorted by   Portfolio ID & Tenor...");

            foreach (var tenor in _tenorReadWriter.OrderByPortfolioIdAndTenor(_tenor))

            {
                Console.WriteLine($"Tenor:{tenor.TenorId} - " +
                                  $"Portfolio Id: {tenor.PortfolioId} " +
                                  $"- Value:{tenor.Value.ToString()}"
                                  );

            }

            Console.WriteLine("Write to file");

            _tempTenor = _tenorReadWriter.OrderByTenorAndPortfolioID(_tenor); 
            _tenorReadWriter.OpenForWrite("3.txt");
           _tenorReadWriter.Write( string.Join(Environment.NewLine,new string[] { "tenor, portfolioid, value" },
                                   _tempTenor.Select(x => $"{x.TenorId},{x.PortfolioId},{x.Value.ToString()}")));

            Console.ReadLine();
            Console.WriteLine("Write to file");

            _tempTenor = _tenorReadWriter.OrderByPortfolioIdAndTenor(_tenor);
            _tenorReadWriter.OpenForWrite("4.txt");
            _tenorReadWriter.Write(string.Join(Environment.NewLine, new string[] { "tenor, portfolioid, value" },
                                    _tempTenor.Select(x => $"{x.TenorId},{x.PortfolioId},{x.Value.ToString()}")));


            Console.ReadLine();
        }



      
    }
}
