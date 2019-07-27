﻿using PCConfigurationTool.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Database.Models
{
    public class PCConfiguration : IPCConfiguration
    {
        #region Declarations

        private ICollection<IPCComponent> pcComponents;        

        #endregion

        #region Initialization

        public PCConfiguration()
        {
            PCComponents = new HashSet<PCComponent>();
        }

        #endregion

        #region Properties

        [Key]
        public int ID { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<PCComponent> PCComponents
        {
            get
            {
                if (pcComponents == null)
                {
                    return null;
                }

                return pcComponents.Select(x => (PCComponent)x).ToList();
            }
            set
            {
                pcComponents = value.Select(x => (IPCComponent)x).ToList();
            }
        }
        
        ICollection<IPCComponent> IPCConfiguration.PCComponents
        {
            get
            {
                return pcComponents;
            }
            set
            {
                pcComponents = value;
            }
        }

        #endregion
    }
}
