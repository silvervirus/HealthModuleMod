using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using HealthFabricatorModule.fabricator;
using RamuneLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

using Nautilus.Assets.Gadgets;
using UnityEngine;
using Nautilus.Extensions;

namespace HealthModuleMod.Equipment.knife
{
    internal class VenomKnife : HeatBlade
       
    {
        public void Start()
        {
            attackDist = 100f;
            damage = 20f;
        }

        public override void OnToolUseAnim(GUIHand hand)
        {
            ErrorMessage.AddError("Knife used to attack");
            base.OnToolUseAnim(hand);
        }
        public static PrefabInfo Info;
        public static Texture2D VenomBladeTexture = Utilities.GetTexture("VenomBladeTexture");
        public static Texture2D VenomBladeIllumTexture = Utilities.GetTexture("VemonBladeIllumTexture");
        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("VenomKnife", "VenomKnife", "Blade dripped in poison from the mushroom", Utilities.GetSprite("VenomBlade"), 2, 2);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(TechType.HeatBlade);
            prefab.SetEquipment(EquipmentType.Hand).WithQuickSlotType(QuickSlotType.Selectable);
            prefab.SetRecipe(Utilities.CreateRecipe(1,
                new Ingredient(TechType.HeatBlade, 1),
                new Ingredient(TechType.GasPod, 1),
                new Ingredient(TechType.AcidMushroom, 4)))
                .WithFabricatorType(HealthFabricatorModule.fabricator.HealthFabricatorModule.CraftTreeType)
                .WithStepsToFabricatorTab("Blades")
                .WithCraftingTime(0.5f);

            var clone = new CloneTemplate(Info, TechType.HeatBlade)
            {
                ModifyPrefab = go =>
                {
                    var renderer = go.GetComponentInChildren<MeshRenderer>(true);
                    foreach (var m in renderer.materials)
                    {
                        m.mainTexture = VenomBladeIllumTexture;
                        m.SetTexture("_SpecTex", VenomBladeIllumTexture);
                        m.SetTexture("_Illum", VenomBladeIllumTexture);
                        m.SetColor("_GlowColor", new Color(0.0f, 1.0f, 0.0f, 1.0f));
                    }
                    var heatblade = go.GetComponent<HeatBlade>();
                    var venomblade = go.EnsureComponent<VenomKnife>().CopyComponent(heatblade);
                    Object.DestroyImmediate(heatblade);
                }
            };


            prefab.SetGameObject(clone);
            prefab.Register();
        }
       
    }
}
