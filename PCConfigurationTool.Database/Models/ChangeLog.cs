using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Database.Models
{
    public class ChangeLog
    {
        #region Properties

        [Key]
        public int ID { get; set; }

        public string EntityName { get; set; }

        public string PropertyName { get; set; }

        public string PrimaryKeyValue { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime DateChanged { get; set; }

        #endregion
    }
}
