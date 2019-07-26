using PCConfigurationTool.Core.Interfaces;
using PCConfigurationTool.Core.Interfaces.Basis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCConfigurationTool
{
    public partial class Form1 : Form, IView
    {
        IFormManager formManager;

        public Form1(/*IFormManager formManager*/)
        {
            //this.formManager = formManager;
            InitializeComponent();
        }
    }
}
