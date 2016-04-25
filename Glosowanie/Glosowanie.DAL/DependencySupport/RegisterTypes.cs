using Glosowanie.DAL.Context;
using Glosowanie.DAL.UnitOfWorkk;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.DAL.DependencySupport
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
            //Repository
            //unityContainer.RegisterType<IAchievementRepository, AchievementRepository>();

            //context
            unityContainer.RegisterType<IGlosowanieContext, GlosowanieContext>();

            //UnitOfWork
            unityContainer.RegisterType<IUnitOfWork, UnitOfWork>();
            unityContainer.RegisterType<DbContext, GlosowanieContext>(new PerResolveLifetimeManager());

            return unityContainer;
        }
    }
}
