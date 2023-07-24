namespace KitchenXLB.Mains
{
    internal class BurntXLB : CustomItem
    {
        public override string UniqueNameID => "burnt_xlb";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("burnt_xlb");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override string ColourBlindTag => "BXLB";
        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChildGame("basket", "Burned");
            Prefab.ApplyMaterialToChildGame("baos", "Burned - Light");
        }
    }
}