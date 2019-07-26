using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace PCConfigurationTool.Database.Models
{
    public class PCComponent : IPCComponent
    {
        public PCComponent()
        {
        }

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
    }
}
