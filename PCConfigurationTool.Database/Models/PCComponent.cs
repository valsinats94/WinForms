﻿using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.Services;
using PCConfigurationTool.Database.Services.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Unity;

namespace PCConfigurationTool.Database.Models
{
    public class PCComponent : IPCComponent, IEquatable<PCComponent>
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
                    pcConfigurations = new ObservableCollection<IPCConfiguration>(/*new PCConfigurationDatabaseService().GetActivePCConfigurations()*/);
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

        #region Overrides
        
        public override int GetHashCode()
        {
            var hashCode = -1045279884;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PCComponent);
        }

        public bool Equals(PCComponent other)
        {
            return other != null &&
                   Code == other.Code;
        }

        public static bool operator ==(PCComponent component1, PCComponent component2)
        {
            return EqualityComparer<PCComponent>.Default.Equals(component1, component2);
        }

        public static bool operator !=(PCComponent component1, PCComponent component2)
        {
            return !(component1 == component2);
        }

        #endregion

        #endregion
    }
}
