using PCConfigurationTool.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Interfaces.Models
{
    public interface IPCComponent
    {
        string Name { get; set; }

        string Code { get; set; }

        string Manufacturer { get; set; }

        string Description { get; set; }

        decimal Price { get; set; }

        byte[] Image { get; set; }

        EntityStatus Status { get; set; }

        ICollection<IPCConfiguration> PCConfigurations { get; set; }
    }
}
