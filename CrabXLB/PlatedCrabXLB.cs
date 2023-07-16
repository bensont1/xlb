namespace KitchenXLB.Mains
{
    internal class PlatedCrabXLB : CustomItemGroup<CrabXLB.View>
    {
        public override string UniqueNameID => "plated_crab_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("crab_xlb_plated");
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Large;

        public override bool CanContainSide => false;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Plate);
        public override Item DirtiesTo => GetGDO<Item>(ItemReferences.PlateDirty);

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlainCrabXLB>(),
                Text = "CrXlb"
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
                    GetCastedGDO<Item, CrabXLB>(),
                    GetGDO<Item>(ItemReferences.Plate)
                }
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.ApplyMaterialToChildCafe("basket", "XLB - \"Basket\"");
            Prefab.ApplyMaterialToChildCafe("baos", "Crab - Raw Shell");
            Prefab.ApplyMaterialToChildCafe("plate", "Plate", "Plate - Ring");
        }
    }
}