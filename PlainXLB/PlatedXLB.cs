namespace KitchenXLB.Mains
{
    internal class PlatedXLB : CustomItemGroup<XLB.View>
    {
        public override string UniqueNameID => "plated_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("xlb_plated");
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Large;

        public override bool CanContainSide => true;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Plate);
        public override Item DirtiesTo => GetGDO<Item>(ItemReferences.PlateDirty);

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlainXLB>(),
                Text = "Xlb"
            },
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Plate),
                    GetCastedGDO<Item, XLB>()
                }
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.ApplyMaterialToChildGame("basket", "XLB - \"Basket\"");
            Prefab.ApplyMaterialToChildGame("baos", "XLB - \"Bao\"");
            Prefab.ApplyMaterialToChildGame("plate", "Plate", "Plate - Ring");
        }
    }
}