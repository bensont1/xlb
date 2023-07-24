using IngredientLib.Ingredient.Items;

namespace KitchenXLB.Mains
{
    internal class UnmixedCrabXLBDough : CustomItemGroup<UnmixedCrabXLBDough.View>
    {
        public override string UniqueNameID => "unmixed_crab_xlb_dough";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("crab_xlb_open");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Knead),
                Duration = 0.3f,
                Result = GetCastedGDO<Item, UncookedCrabXLB>()
            }
        };

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetGDO<Item>(ItemReferences.CrabChopped),
                Text = "Cc"
            },
            new()
            {
                Item = GetGDO<Item>(ItemReferences.Dough),
                Text = "Do"
            },
            new()
            {
                Item = GetCastedGDO<Item, PortionedXLBSoup>(),
                Text = "Sp"
            }
        };
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Dough),
                    
                        
                },
                IsMandatory = true,
                Max = 1,
                Min = 1,
            },
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.CrabChopped),
                    GetCastedGDO<Item, PortionedXLBSoup>(),
                },
                Max = 2,
                Min = 2
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.TryAddComponent<View>().Setup(gdo);

            Prefab.ApplyMaterialToChild("DumplingsOpen", "Raw Pastry");
            Prefab.ApplyMaterialToChildGame("Meat - Chopped", "Crab - Raw Meat", "Crab - Raw Shell");
            Prefab.ApplyMaterialToChildGame("Carrot - Chopped", "Soup");

        }

        public class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    GameObject = gameObject.GetChild("Meat - Chopped"),
                    Item = GetGDO<Item>(ItemReferences.CrabChopped)
                },
                new()
                {
                    GameObject = gameObject.GetChild("Carrot - Chopped"),
                    Item = GetCastedGDO<Item, PortionedXLBSoup>()
                }
            };
        }
    }
}
