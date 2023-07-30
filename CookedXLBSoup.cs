namespace KitchenXLB.Mains
{
    internal class CookedXLBSoup : CustomItem
    {
        public override string UniqueNameID => "cooked_xlb_soup";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("cooked_xlb_soup");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override int SplitCount => 7;
        public override Item SplitSubItem => GetCastedGDO<Item, PortionedXLBSoup>();
        public override List<Item> SplitDepletedItems => new() { GetGDO<Item>(ItemReferences.SoupDepleted) };
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);
        public override float SplitSpeed => 1.5f;

/*        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, BurntJelly>(),
                Duration = 10,
                IsBad = true,
                Process = GetGDO<Process>(ProcessReferences.Cook)
            }
        };*/

        public override void OnRegister(Item gdo)
        {
            var pot = Prefab.GetChild("Pot/Pot.001");
            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.003", "Metal Dark");

            var pumpkin = Prefab.GetChild("Pumpkin Group");
            pumpkin.ApplyMaterialToChild("Pumpkin", "Soup - Meat");

            pumpkin.GetChild("Pumpkin/Pumpkin - Chopped").ApplyMaterialToChild("Meat - Chopped.001", "Soup");
            pumpkin.GetChild("Pumpkin/Pumpkin - Chopped").ApplyMaterialToChild("Meat - Chopped.002", "Soup");
        }
    }
}