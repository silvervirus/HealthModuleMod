using System;
using System.Collections.Generic;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus.Utility;
using static CraftData;
using Nautilus.Assets.Gadgets;
using UnityEngine;
using Nautilus.Handlers;
using HealthModuleMod.Equipment;
using HarmonyLib;
using System.Collections;
using BepInEx;
using RamuneLib;
using HarmonyLib;

namespace HealthFabricatorModule.fabricator
{
    [BepInPlugin(HealthFabricatorModule.PLUGIN_GUID, HealthFabricatorModule.PLUGIN_NAME, HealthFabricatorModule.PLUGIN_VERSION)]
    [BepInProcess("Subnautica.exe")]
    public class HealthFabricatorModule : BaseUnityPlugin
    {
        public const String PLUGIN_GUID = "SN.HealthFabricator";
        public const String PLUGIN_NAME = "Ancient Module Recreator";
        public const String PLUGIN_VERSION = "1.2.0";
        public static CraftTree.Type CraftTreeType;
        private static readonly Harmony harmony = new Harmony(PLUGIN_GUID);

        public void Awake()
             

        {
           
            var prefab = new CustomPrefab("HealthFabricator", "Ancient Module Recreator", "Construct Player upgrade modules So you can survive more deadly wounds, or even deliver them yourself.Or experience The terraformer's abilety to transform terain(The modifications are cleared from save files to prevent corrupt save files", Utilities.GetSprite("MissingFabricator"));
            var fabTree = prefab.CreateFabricator(out CraftTree.Type fabTreeType);
            var model = new FabricatorTemplate(prefab.Info, fabTreeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Fabricator,
                ModifyPrefab = go =>
                {
                    var renderer = go.GetComponentInChildren<SkinnedMeshRenderer>(true);

                }
            };
            prefab.SetGameObject(model);
            prefab.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 1), new Ingredient(TechType.FiberMesh, 2), new Ingredient(TechType.JeweledDiskPiece, 1)));
            prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);
            prefab.Register();

            CraftTreeHandler.AddTabNode(fabTreeType, "Chips", "Chips", SpriteManager.Get(TechType.ComputerChip));
            CraftTreeHandler.AddTabNode(fabTreeType, "Blades", "Blades", SpriteManager.Get(TechType.HeatBlade));
            CraftTreeHandler.AddTabNode(fabTreeType, "DeletedTools", "DeletedTools", SpriteManager.Get(TechType.Transfuser));


            CraftTreeType = fabTreeType;

            Main.FindPiracy();
            VenomKnife.Patch();
            FlatHealthModule.Patch();
            HealthModuleMod.Equipment.Terraformer.Patch();
            HealthModuleMod.Equipment.Transfuser.Patch();
            harmony.PatchAll();

        }
       

       
      
    }
}


   

