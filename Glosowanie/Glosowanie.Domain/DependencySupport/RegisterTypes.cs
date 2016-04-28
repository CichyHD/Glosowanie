using Glosowanie.Domain.Providers;
using Glosowanie.Domain.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Domain.DependencySupport
{
    public class RegisterTypes
    {
        private readonly IUnityContainer unityContainer;

        public RegisterTypes(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        public IUnityContainer BuildUnityContainer()
        {
            new Glosowanie.DAL.DependencySupport.RegisterTypes(unityContainer).BuildUnityContainer();

            unityContainer.RegisterType<IExcelProvider, ExcelProvider>();
            unityContainer.RegisterType<IPoolService, PoolService>();

            return unityContainer;
        }
    }
}
