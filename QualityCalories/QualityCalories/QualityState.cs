using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONI_Common.Json;

namespace QualityCalories
{
    class QualityState
    {
        public int Quality { get; set; } = 1;
        public string QualityColor { get; set; } = "yellow";

        public static BaseStateManager<QualityState> StateManager
               = new BaseStateManager<QualityState>("QualityCalories");
    }
}
