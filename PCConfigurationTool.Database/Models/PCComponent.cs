using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PCConfigurationTool.Database.Models
{
    public class PCComponent : IPCComponent
    {
        #region Declarations

        private ObservableCollection<IPCConfiguration> pcConfigurations;

        #endregion

        #region Initialization
        
        public PCComponent()
        {
            Configurations = new HashSet<PCConfiguration>();
        }

        #endregion

        #region Properties
        
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public EntityStatus Status { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<PCConfiguration> Configurations { get; set; }
        
        public ICollection<IPCConfiguration> PCConfigurations
        {
            get
            {
                if (pcConfigurations == null)
                {
                    pcConfigurations = new ObservableCollection<IPCConfiguration>(Configurations);
                    pcConfigurations.CollectionChanged += Configurations_CollectionChanged;
                }

                return pcConfigurations;
            }
        }

        #endregion

        #region Methods

        private void Configurations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add && e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    this.Configurations.Add(item as PCConfiguration);
                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove && e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    this.Configurations.Remove(item as PCConfiguration);
                }
            }
        }

        #endregion
    }
}
