using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Interfaces.ViewModels
{
    public interface IConfigurePCViewModel
    {
        ICollection<IPCComponent> PCComponents { get; }

        ICollection<IPCComponent> ChosenPCComponents { get; }

        IPCComponent SelectedComponent { get; set; }

        EntityStatus Status { get; set; }

        ConfigurationType ConfigurationType { get; set; }

        decimal? Coefficient { get; set; }

        decimal TotalPrice { get; set; }

        void AddComponentToConfiguration(IPCComponent pCComponent);

        IList<ValidationResult> Validate();

        bool ApplyChanges();

        bool Save();
    }
}
