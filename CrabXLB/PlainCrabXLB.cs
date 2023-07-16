namespace KitchenXLB.Mains
{
    internal class PlainCrabXLB : CustomItem
    {
        public override string UniqueNameID => "plain_crab_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("crab_xlb");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override string ColourBlindTag => "Cr";

        public override void OnRegister(Item gdo)
        {

        }
    }
}