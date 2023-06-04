using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

namespace HealthModuleMod.Equipment
{
    internal class Transfuser
    {
        public static void Patch()
        {
            RecipeData fuser = new RecipeData();
            CraftDataHandler.GetRecipeData(TechType.Transfuser);
            fuser = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Titanium, 4)
                   
                }
            };
            CraftDataHandler.SetRecipeData((TechType)1259, fuser);
            CraftTreeHandler.AddCraftingNode(HealthFabricatorModule.fabricator.HealthFabricatorModule.CraftTreeType, TechType.Transfuser, new string[]
            {
               "DeletedTools"
            });
        }
    }
}
