using PCConfigurationTool.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Interfaces.Models
{
    public interface IPCConfiguration
    {
        decimal TotalPrice { get; set; }

        ICollection<IPCComponent> PCComponents { get; }

        ConfigurationType ConfigurationType { get; set; }

        EntityStatus Status { get; set; }
    }
}
