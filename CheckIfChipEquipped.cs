using System;
using HarmonyLib;
using HealthModuleMod.Equipment.chip;

namespace HealthModuleMod
{
	// Token: 0x02000003 RID: 3
	[HarmonyPatch(typeof(Player))]
	[HarmonyPatch("EquipmentChanged")]
	internal class CheckIfChipEquipped
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002200 File Offset: 0x00000400
		public static bool Prefix(Player __instance, FlatHealthModule flatHealthModule)
		{
			Inventory main = Inventory.main;
			int count = main.equipment.GetCount(FlatHealthModule.Info.TechType);
			bool flag = count > CheckIfChipEquipped.EquippedHealthModulesAmount;
			if (flag)
			{
				CheckIfChipEquipped.IncreasePlayerHealth(__instance, (float)(1 + count) * 100f);
				CheckIfChipEquipped.EquippedHealthModulesAmount = count;
			}
			else
			{
				bool flag2 = count < CheckIfChipEquipped.EquippedHealthModulesAmount;
				if (flag2)
				{
					CheckIfChipEquipped.DecreasePlayerHealth(__instance, (float)(1 + count) * 100f);
					CheckIfChipEquipped.EquippedHealthModulesAmount = count;
				}
			}
			return true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002278 File Offset: 0x00000478
		public static void IncreasePlayerHealth(Player player, float amount)
		{
			player.liveMixin.data.maxHealth = amount;
			player.liveMixin.health += 100f;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000022A3 File Offset: 0x000004A3
		public static void DecreasePlayerHealth(Player player, float amount)
		{
			player.liveMixin.data.maxHealth = amount;
			player.liveMixin.health -= 100f;
		}

		// Token: 0x04000003 RID: 3
		public static int EquippedHealthModulesAmount = 0;
	}
}
