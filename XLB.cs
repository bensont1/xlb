
namespace KitchenXLB.Mains
{
    internal class XLB : CustomItemGroup<XLB.View>
    {
        public override string UniqueNameID => "xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("xlb");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlainXLB>(),
                Text = "Pl"
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
                    GetCastedGDO<Item, PlainXLB>()
                }
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.TryAddComponent<View>().Setup(gdo);

            Prefab.ApplyMaterialToChildCafe("basket", "XLB - \"Basket\"");
            Prefab.ApplyMaterialToChildCafe("baos", "XLB - \"Bao\"");
        }

        public class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, PlainXLB>(),
                    GameObject = gameObject.GetChild("xlb")
                }
            };
        }
    }
}