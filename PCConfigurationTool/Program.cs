﻿using PCConfigurationTool.Core;
using PCConfigurationTool.Core.Interfaces;
using PCConfigurationTool.Core.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PCConfigurationTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IUnityContainer container = new UnityContainer();
            Bootstrapper bootstrapper = new Bootstrapper(container);
            
            Form form = container.Resolve<IEntryView>() as Form;
            Application.Run(form);
        }
    }
}
