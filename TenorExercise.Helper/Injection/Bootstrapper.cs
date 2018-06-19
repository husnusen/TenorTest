using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorExercise.Helper.Injection
{
   public class Bootstrapper
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer InitializeContainer()
        {
            return _container ?? (_container = new WindsorContainer().Install(new Installer()));
        }
    }
}
