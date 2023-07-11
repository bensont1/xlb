namespace KitchenXLB.Mains
{
    internal class UncookedXLB: CustomItem
    {
        public override string UniqueNameID => "uncooked_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("xlb_uncooked");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Duration = 3.5f,
                Result = GetCastedGDO<Item, XLB>()
            }
        };

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("baos", "XLB - \"Bao\"");
        }
    }
}