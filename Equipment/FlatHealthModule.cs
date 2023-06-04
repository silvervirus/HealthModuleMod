using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using RamuneLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;
using Nautilus.Assets.Gadgets;

namespace HealthModuleMod.Equipment
{
    internal class FlatHealthModule
    {
        public static PrefabInfo Info;
        public static void Patch()
        {
            Info = Utilities.CreatePrefabInfo("FlatHealthModule", "Subdurmal Body protection", "this Module makes the user more healthy so more attacks can be taken without them being lethal. Module Stacks", Utilities.GetSprite("FlatHealthModule"), 2, 2);
            var prefab = new CustomPrefab(Info);
            var clone = new CloneTemplate(Info, TechType.ComputerChip);

            prefab.SetGameObject(clone);
            prefab.SetUnlock(TechType.ComputerChip);
            prefab.SetEquipment(EquipmentType.Chip).WithQuickSlotType(QuickSlotType.None);
            prefab.SetRecipe(Utilities.CreateRecipe(1,
                new Ingredient(TechType.Titanium, 6),
                new Ingredient(TechType.FiberMesh, 4)))
                .WithFabricatorType(HealthFabricatorModule.fabricator.HealthFabricatorModule.CraftTreeType)
                .WithStepsToFabricatorTab("Chips")
                .WithCraftingTime(0.5f);
            prefab.Register();
        }
    }
}