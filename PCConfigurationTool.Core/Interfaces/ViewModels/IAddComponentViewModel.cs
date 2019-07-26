using PCConfigurationTool.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Interfaces.ViewModels
{
    public interface IAddComponentViewModel
    {
        string Name { get; set; }

        string Manufacturer { get; set; }

        string Description { get; set; }

        decimal Price { get; set; }

        EntityStatus Status { get; set; }

        byte[] Image { get; set; }

        bool Save();
    }
}
