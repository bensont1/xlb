namespace KitchenXLB.Mains
{
    internal class PlainXLB : CustomItem
    {
        public override string UniqueNameID => "plain_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("xlb");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override string ColourBlindTag => "Pl";
        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChildGame("basket", "XLB - \"Basket\"");
            Prefab.ApplyMaterialToChildGame("baos", "XLB - \"Bao\"");
        }
    }
}