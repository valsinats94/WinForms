﻿using PCConfigurationTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PCConfigurationTool.Database
{
    [Export(typeof(IModule))]
    public class DatabaseModule : IModule
    {
        IUnityContainer container;

        public DatabaseModule(IUnityContainer container)
        {
            this.container = container;
            RegisterServices();
        }

        public void RegisterServices()
        {
            
        }
    }
}
