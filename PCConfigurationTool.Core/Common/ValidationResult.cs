using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Common
{

    public class ValidationResult
    {

        #region Initialization

        public ValidationResult()
            : this(ErrorLevel.NoError, string.Empty) { }

        public ValidationResult(ErrorLevel errorLevel, string description)
        {
            ErrorLevel = errorLevel;
            Message = description;
        }

        #endregion

        #region General Properties

        public ErrorLevel ErrorLevel
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public static ValidationResult NoError
        {
            get
            {
                return new ValidationResult();
            }
        }

        #endregion
    }
}
