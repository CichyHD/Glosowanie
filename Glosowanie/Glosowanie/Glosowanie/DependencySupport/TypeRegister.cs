using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Glosowanie.DependencySupport
{
    public class TypeRegister : ITypeRegister
    {
        private readonly IUnityContainer unityContainer;

        public TypeRegister(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        public IUnityContainer BuildUnityContainer()
        {
            new Glosowanie.Domain.DependencySupport.RegisterTypes(unityContainer).BuildUnityContainer();

            return unityContainer;
        }
    }
}