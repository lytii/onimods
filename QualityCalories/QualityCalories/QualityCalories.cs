using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;

namespace QualityCalories
{

    [HarmonyPatch(typeof(MeterScreen))]
    [HarmonyPatch("RefreshRations")]
    public static class TemplateMod_MeterScreen_RefreshRations
    {
        public static void Postfix(MeterScreen __instance)
        {
            __instance.RationsText.text = RationUtil.CountRation();
        }
    }

    [HarmonyPatch(typeof(MeterScreen))]
    [HarmonyPatch("OnRationsTooltip")]
    public static class TemplateMod_Game_OnPrefabInit
    {
        public static void Postfix(MeterScreen __instance)
        {
            __instance.RationsText.text = RationUtil.CountRation();
        }
    }

    public static class RationUtil
    {
        static int quality = QualityState.StateManager.State.Quality;
        public static string CountRation()
        {
            float num = 0.0f;
            float qualityCalories = 0.0f;
            List<Pickupable> pickupables = WorldInventory.Instance.GetPickupables(GameTags.Edible);
            if (pickupables != null)
            {
                foreach (Pickupable pickupable in pickupables)
                {
                    if (!pickupable.KPrefabID.HasTag(GameTags.StoredPrivate))
                    {
                        Edible component = pickupable.GetComponent<Edible>();
                        if (component.GetQuality() >= quality) {
                            qualityCalories += component.Calories;
                        }
                        num += component.Calories;
                    }
                }   
            }

            return string.Format(
                "{0}\n<color=\"{1}\"><b>{2}</b></color> ({3})",
                GameUtil.GetFormattedCalories((float)num, GameUtil.TimeSlice.None, true),
                QualityState.StateManager.State.QualityColor,
                GameUtil.GetFormattedCalories((float)qualityCalories, GameUtil.TimeSlice.None, true),
                quality
                );
        }
    }
}
