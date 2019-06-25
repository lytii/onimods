using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONI_Common.Json;

namespace DefaultPriority
{
    class DefaultPriorityState
    {
        public bool Enabled { get; set; } = true;
        public int DefaultBuildPriority { get; set; } = 4;
        public int DefaultToolPriority { get; set; } = 4;

        public static BaseStateManager<DefaultPriorityState> StateManager
            = new BaseStateManager<DefaultPriorityState>("DefaultPriority");
    }
}
