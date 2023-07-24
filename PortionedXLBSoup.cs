namespace KitchenXLB.Mains
{
    internal class PortionedXLBSoup : CustomItem
    {
        public override string UniqueNameID => "portioned_xlb_soup";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("portioned_xlb_soup");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChildGame("portioned_xlb_soup", "Soup");
        }
    }
}