using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PCConfigurationTool.Database.Models
{
    public class PCComponent : IPCComponent
    {
        #region Declarations

        private ICollection<IPCConfiguration> pcConfigurations;

        #endregion

        #region Initialization
        
        public PCComponent()
        {
            PCConfigurations = new HashSet<PCConfiguration>();
        }

        #endregion

        #region Properties
        
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public EntityStatus Status { get; set; }

        public byte[] Image { get; set; }

        public ICollection<PCConfiguration> PCConfigurations
        {
            get
            {
                if (pcConfigurations == null)
                {
                    return null;
                }

                return pcConfigurations.Select(x => (PCConfiguration)x).ToList();
            }
            set
            {
                pcConfigurations = value.Select(x => (IPCConfiguration)x).ToList();
            }
        }

        ICollection<IPCConfiguration> IPCComponent.PCConfigurations
        {
            get
            {
                return pcConfigurations;
            }
            set
            {
                pcConfigurations = value;
            }
        }

        #endregion
    }
}
