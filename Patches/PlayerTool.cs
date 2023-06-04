using HarmonyLib;
using HealthModuleMod.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthModuleMod.Patches
{
    internal class PlayerTools
    {
        [HarmonyPatch(typeof(PlayerTool), nameof(PlayerTool.animToolName), MethodType.Getter)]
        public static class PlayerToolPatch
        {
            public static void Postfix(PlayerTool __instance, ref string __result)
            {

                if (__instance.pickupable?.GetTechType() == VenomKnife.Info.TechType) __result = "knife";
            }
        }
    }
}