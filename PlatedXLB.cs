namespace KitchenXLB.Mains
{
    internal class PlatedXLB : CustomItemGroup<XLB.View>
    {
        public override string UniqueNameID => "plated_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("xlb_plated");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Medium;

        public override bool CanContainSide => false;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Plate);
        public override Item DirtiesTo => GetGDO<Item>(ItemReferences.PlateDirty);

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlainXLB>(),
                Text = "Pl"
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
                    GetCastedGDO<Item, XLB>(),
                    GetGDO<Item>(ItemReferences.Plate)
                }
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
         /*   Prefab.TryAddComponent<XLB.View>().Setup(gdo);*/

            Prefab.ApplyMaterialToChildCafe("basket", "XLB - \"Basket\"");
            Prefab.ApplyMaterialToChildCafe("baos", "XLB - \"Bao\"");
            Prefab.ApplyMaterialToChildCafe("plate", "Plate", "Plate - Ring");
        }
    }
}