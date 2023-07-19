namespace KitchenXLB.Mains
{
    internal class PlainTruffleXLB : CustomItem
    {
        public override string UniqueNameID => "plain_truffle_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("truffle_xlb");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override string ColourBlindTag => "Tr";

        public override void OnRegister(Item gdo)
        {

        }
    }
}