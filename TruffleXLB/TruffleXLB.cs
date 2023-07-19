namespace KitchenXLB.Mains
{
    internal class TruffleXLB : CustomItemGroup<TruffleXLB.View>
    {
        public override string UniqueNameID => "truffle_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("truffle_xlb");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

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
            /*  Prefab.TryAddComponent<View>().Setup(gdo);*/

            Prefab.ApplyMaterialToChildCafe("basket", "XLB - \"Basket\"");
            Prefab.ApplyMaterialToChildCafe("baos", "Oyster");
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