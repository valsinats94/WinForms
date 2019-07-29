using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PCConfigurationTool.Database.Models
{
    public class PCConfiguration : IPCConfiguration
    {
        #region Declarations

        private ObservableCollection<IPCComponent> pcComponents;        

        #endregion

        #region Initialization

        public PCConfiguration()
        {
            Components = new HashSet<PCComponent>();
        }

        #endregion

        #region Properties

        [Key]
        public int ID { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ICollection<PCComponent> Components { get; set; }
        
        public ICollection<IPCComponent> PCComponents
        {
            get
            {
                if(pcComponents == null)
                {
                    pcComponents = new ObservableCollection<IPCComponent>(Components);
                    pcComponents.CollectionChanged += Components_CollectionChanged;
                }

                return pcComponents;
            }
        }
        
        public ConfigurationType ConfigurationType { get; set; }

        public EntityStatus Status { get; set; }

        #endregion

        #region Methods

        private void Components_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add && e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    this.Components.Add(item as PCComponent);
                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove && e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    this.Components.Remove(item as PCComponent);
                }
            }
        }

        #endregion
    }
}
