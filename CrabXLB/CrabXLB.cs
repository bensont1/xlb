namespace KitchenXLB.Mains
{
    internal class CrabXLB : CustomItemGroup<CrabXLB.View>
    {
        public override string UniqueNameID => "crab_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("crab_xlb");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, BurntXLB>(),
                Duration = 15.0f,
                IsBad = true,
                Process = GetGDO<Process>(ProcessReferences.Cook)
            }
        };

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlainCrabXLB>(),
                Text = "Cr"
            }
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new()
                {
                    GetCastedGDO<Item, PlainCrabXLB>()
                }
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.ApplyMaterialToChildGame("basket", "XLB - \"Basket\"");
            Prefab.ApplyMaterialToChildGame("baos", "Crab - Raw Shell");
        }

        public class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, PlainCrabXLB>(),
                    GameObject = gameObject.GetChild("xlb")
                }
            };
        }
    }
}