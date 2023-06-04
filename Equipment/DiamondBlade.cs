using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus;
using static CraftData;
using Nautilus.Handlers;
using System.Collections.Generic;

namespace HealthModuleMod.Equipment
{
    internal class DiamondBlade
    {
        
        public void Patch()
        {
            RecipeData diamondknife = new RecipeData();
            CraftDataHandler.GetRecipeData(TechType.DiamondBlade);
            diamondknife = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient((TechType)(TechType)1547, 1),
                    new Ingredient((TechType)2504, 1),
                    new Ingredient((TechType)(TechType)63, 1)
                }
            };
            CraftDataHandler.SetRecipeData(TechType.DiamondBlade, diamondknife);
            CraftTreeHandler.AddCraftingNode(HealthFabricatorModule.fabricator.HealthFabricatorModule.CraftTreeType, TechType.DiamondBlade, new string[]
            {
                "Blades"
            }) ;
        }
    }
}
