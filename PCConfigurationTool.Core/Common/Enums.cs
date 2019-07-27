using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Common
{
    public enum EntityStatus
    {
        Deleted = 1,
        Edited,
        Current,
    }

    public enum ErrorLevel
    {
        NoError = 0,
        NonCritical = 1,
        Critical = 2,
    }

    public enum ConfigurationType
    {
        Ordinary = 1 << 0,
        ExtraOrdinary = 1 << 1,
    }
}
