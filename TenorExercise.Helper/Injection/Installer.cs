using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenorExercise.Helper;
using TenorExercise.Helper.Interfaces;

namespace TenorExercise.Helper.Injection
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFileWriter>().ImplementedBy<FileWriter>().LifestyleTransient());
            container.Register(Component.For<IFileReader>().ImplementedBy<FileReader>().LifestyleTransient());

        }
    }
}
