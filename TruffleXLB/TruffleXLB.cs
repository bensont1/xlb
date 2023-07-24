namespace KitchenXLB.Mains
{
    internal class TruffleXLB : CustomItemGroup<TruffleXLB.View>
    {
        public override string UniqueNameID => "truffle_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("truffle_xlb");
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
                Item = GetCastedGDO<Item, PlainTruffleXLB>(),
                Text = "Tr"
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
                    GetCastedGDO<Item, PlainTruffleXLB>()
                }
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.ApplyMaterialToChildGame("basket", "XLB - \"Basket\"");
            Prefab.ApplyMaterialToChildGame("baos", "Oyster");
        }

        public class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, PlainTruffleXLB>(),
                    GameObject = gameObject.GetChild("xlb")
                }
            };
        }
    }
}