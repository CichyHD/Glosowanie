﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.DependencySupport
{
    interface ITypeRegister
    {
        Microsoft.Practices.Unity.IUnityContainer BuildUnityContainer();
    }
}