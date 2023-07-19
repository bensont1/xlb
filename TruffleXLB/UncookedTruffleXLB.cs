namespace KitchenXLB.Mains
{
    internal class UncookedTruffleXLB : CustomItem
    {
        public override string UniqueNameID => "uncooked_truffle_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("truffle_xlb_uncooked");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Duration = 1.0f,
                Result = GetCastedGDO<Item, TruffleXLB>()
            }
        };

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("baos", "Oyster");
        }
    }
}