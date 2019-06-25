using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using UnityEngine;

namespace DefaultPriority
{
    [HarmonyPatch(typeof(PriorityScreen), "InstantiateButtons")]
    internal class DefaultPriority_PriorityScreen_OnPrefabInit
    {
        private static void Postfix(PriorityScreen __instance)
        {
            __instance.SetScreenPriority(new PrioritySetting(PriorityScreen.PriorityClass.basic, DefaultPriorityState.StateManager.State.DefaultBuildPriority), false);
        }
    }

    [HarmonyPatch(typeof(PriorityScreen), "ResetPriority")]
    internal class DefaultPriority_PriorityScreen_ResetPriority
    {
        private static void Postfix(PriorityScreen __instance)
        {
            __instance.SetScreenPriority(new PrioritySetting(PriorityScreen.PriorityClass.basic, DefaultPriorityState.StateManager.State.DefaultToolPriority), false);
        }
    }
}
