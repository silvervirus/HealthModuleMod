using Nautilus.Crafting;
using Nautilus.Handlers;
using RamuneLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

namespace HealthModuleMod.Equipment
{
    internal class Terraformer
    {
        public static void Patch()
        {
            RecipeData Terra = new RecipeData();
            CraftDataHandler.GetRecipeData(TechType.Terraformer);
            Utilities.GetSprite("TerraFormer");
            Terra = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Titanium, 4),
                    new Ingredient(TechType.CopperWire, 2),
                    new Ingredient(TechType.ComputerChip, 1)
                }
            };
            CraftDataHandler.SetRecipeData(TechType.Terraformer, Terra);
            CraftTreeHandler.AddCraftingNode(HealthFabricatorModule.fabricator.HealthFabricatorModule.CraftTreeType, TechType.Terraformer, new string[]
            {
               "DeletedTools"
            });
        }
    }
}
